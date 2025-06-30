
using Bogus;

namespace VanArsdel.DataGenerator.Generators;

public static class InventoryGenerator
{
    public static List<Inventory> GenerateInventories(
        List<Store> stores,
        List<ProductCategory> productCategories,
        List<ProductCatalog> productCatalogs,
        List<SupplierProfile> supplierProfiles,
        string fxCsvPath,
        int skuPerStore = 500)
    {
        var fxRates = FxLoader.Load(fxCsvPath);
        var faker = new Faker();
        var inventories = new List<Inventory>(stores.Count * skuPerStore);

        var categoryMap = productCategories
            .ToDictionary(c => c.ProductCategoryId, c =>
            {
                var categoryName = c.Name;
                var parent = ProductCategoryDefinitions
                    .FirstOrDefault(d => d.subs.Contains(categoryName)).parent;
                return (categoryName, parent);
            });

        foreach (var store in stores)
        {
            const string inHouseBrandName = "VanArsdel Home";
            var inHouseBrandRatio = 0.4;  // $% bias for in-house brand


            // Separate SKUs by brand
            var inHouseSkus = productCatalogs.Where(p => p.Brand == inHouseBrandName).ToList();
            var externalSkus = productCatalogs.Where(p => p.Brand != inHouseBrandName).ToList();

            // Calculate number of SKUs to pick from each group
            int inHouseCount = (int)Math.Round(skuPerStore * inHouseBrandRatio);
            int externalCount = skuPerStore - inHouseCount;

            // Ensure we don't try to take more SKUs than available
            inHouseCount = Math.Min(inHouseCount, inHouseSkus.Count);
            externalCount = Math.Min(externalCount, externalSkus.Count);

            // Adjust counts if one group didn't have enough, try to fill from the other
            if (inHouseCount < (int)Math.Round(skuPerStore * inHouseBrandRatio))
            {
                externalCount = Math.Min(skuPerStore - inHouseCount, externalSkus.Count);
            }
            else if (externalCount < skuPerStore - (int)Math.Round(skuPerStore * inHouseBrandRatio))
            {
                inHouseCount = Math.Min(skuPerStore - externalCount, inHouseSkus.Count);
            }


            // Randomly select SKUs from each group
            var selectedInHouseSkus = inHouseSkus.OrderBy(_ => faker.Random.Double()).Take(inHouseCount);
            var selectedExternalSkus = externalSkus.OrderBy(_ => faker.Random.Double()).Take(externalCount);

            // Combine the selections
            var skusForStore = selectedInHouseSkus.Concat(selectedExternalSkus).ToList();

            // Shuffle the combined list if the order matters
            skusForStore = skusForStore.OrderBy(_ => faker.Random.Double()).ToList();
            // Currency for this store
            var currency = CurrencyCountryMap[store.Country];

            foreach (var sku in skusForStore)
            {
                var (subCategory, parentCategory) = categoryMap[sku.CategoryId];

                // Initial inventory snapshot date = a random date in the last 30 days of store open date
                var randomDate = store.OpenDate.AddDays(faker.Random.Int(-30, -1));
                var locale = GetCountryLocale(store.Country);
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById(LocaleTimeZones[locale]);
                var lastReceivedDate = TimeZoneInfo.ConvertTime(
                    new DateTime(
                        randomDate.Year,
                        randomDate.Month,
                        randomDate.Day,
                        faker.Random.Int(9, 15),
                        faker.Random.Int(0, 59),
                        faker.Random.Int(0, 59),
                        DateTimeKind.Unspecified),
                    timeZone);

                // stock levels
                var range = StockLevelRanges[parentCategory];
                var stockQty = faker.Random.Int(range.min, range.max);

                // reorder stock level as 20 - 50% of min stock level
                var reorderLevel = faker.Random.Int(
                    (int)(range.min * 0.2),
                    (int)(range.min * 0.5));

                // supplier selection: in-house brand uses own supplier
                SupplierProfile supplier;
                if (sku.Brand == inHouseBrandName)
                {
                    supplier =
                        supplierProfiles.First(s => s.Country == store.Country && s.Name == inHouseBrandName);
                }
                else
                {
                    var externalSuppliers = supplierProfiles
                        .Where(s => s.Country == store.Country && s.Name != inHouseBrandName)
                        .ToList();

                    // use the square root of the reliability score as weights to reduce the difference between high and low scores
                    var weights = externalSuppliers
                        .Select(s => Math.Sqrt(s.ReliabilityScore))
                        .ToArray();
                    supplier = PickWeighted(faker.Random, externalSuppliers, weights);
                }

                // Pricing: USD range then convert to local currency
                var priceRange = ProductCategoryPriceRanges[subCategory];
                var priceInUsd = Math.Round(faker.Random.Decimal(priceRange.min, priceRange.max), 2);
                var ym = lastReceivedDate.ToString("yyyy-MM");
                var fxRate = fxRates.TryGetValue(ym, out var bucket) && bucket.TryGetValue(currency, out var rate)
                    ? rate
                    : 1m;
                var localPrice = Math.Round(priceInUsd * fxRate, 2);

                inventories.Add(new Inventory()
                {
                    InventoryId = Guid.NewGuid(),
                    CurrencyCode = currency,
                    LastReceived = lastReceivedDate,
                    Price = localPrice,
                    PriceUsd = priceInUsd,
                    ProductId = sku.ProductId,
                    ReorderLevel = reorderLevel,
                    StockQuantity = stockQty,
                    StoreId = store.StoreId,
                    SupplierId = supplier.SupplierId
                });
            }
        }

        return inventories;

    }

    /// <summary>
    ///     Picks an item weighted by the given weights.
    /// </summary>
    private static T PickWeighted<T>(Randomizer rng, List<T> items, double[] weights)
    {
        // Normalize weights to sum to 1 for robust probability calculation
        var totalWeight = weights.Sum();
        if (totalWeight <= 0 || items.Count == 0 || items.Count != weights.Length)
        {
            // Handle edge cases: no items, no positive weights, or mismatch length
            return items.Any() ? items[rng.Number(0, items.Count - 1)] : default!;
        }

        var normalizedWeights = weights.Select(w => w / totalWeight).ToArray();

        var roll = rng.Double(); // Generates a value between 0.0 and 1.0
        double cumulative = 0;
        for (var i = 0; i < items.Count; i++)
        {
            cumulative += normalizedWeights[i];
            if (roll <= cumulative)
                return items[i];
        }
        // Fallback in case of floating point inaccuracies
        return items[^1];
    }
}