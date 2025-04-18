using Bogus;
using VanArsdel.DataGenerator.Domains.Retail;

namespace VanArsdel.DataGenerator.Generators;

public static class ProductCatalogGenerator
{
    public static List<ProductCatalog> GenerateProductCatalog(List<ProductCategory> categories, int totalSkus = 1000)
    {
        var weightedBrands = BrandDistribution
            .SelectMany(kv => Enumerable.Repeat(kv.Key, (int)Math.Round(kv.Value * 100)))
            .ToList();

        var subCategories = ProductCategoryDefinitions.SelectMany(c => c.subs).ToList();

        var faker = new Faker();
        var products = new List<ProductCatalog>(totalSkus);

        for (var i = 0; i < totalSkus; i++)
        {
            // Randomly select a subcategory and find its parent category
            var subCategoryName = faker.PickRandom(subCategories);
            var parentCategoryName = ProductCategoryDefinitions
                .First(c => c.subs.Contains(subCategoryName)).parent;

            // Find the category ID for the selected subcategory
            var categoryId = categories
                .First(c => c.Name == subCategoryName).ProductCategoryId;

            // pick the brand
            var brand = faker.PickRandom(weightedBrands);

            // pick the material
            var materialInfo = MaterialMap[parentCategoryName];
            var weightedMaterials = materialInfo.Materials
                .SelectMany((m, idx) => Enumerable.Repeat(m, (int)Math.Round(materialInfo.Weights[idx] * 100)))
                .ToArray();
            var material = faker.PickRandom(weightedMaterials);

            // add a new product
            products.Add(new ProductCatalog()
            {
                ProductId = Guid.NewGuid(),
                Name = $"{material} {subCategoryName}",
                Brand = brand,
                CategoryId = categoryId,
                Material = material
            });
        }
        
        return products;
    }
}