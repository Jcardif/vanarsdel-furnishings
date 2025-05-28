

namespace VanArsdel.DataGenerator.Generators
{
    /// <summary>
    /// Generates a schedule of definitive promotions (seasonal and holiday) for each store,
    /// using data-driven definitions to eliminate duplication and ensure DRY.
    /// </summary>
    public static class PromotionScheduleGenerator
    {
        // Seasons definitions: name, northern start (month, day), northern end (month, day),
        // southern offsets applied automatically
        private static readonly List<SeasonDefinition> Seasons = new()
        {
            new SeasonDefinition("Spring", (3,1), (5,31)),
            new SeasonDefinition("Summer", (6,1), (8,31)),
            new SeasonDefinition("Autumn", (9,1), (11,30), usName: "Fall"),
            new SeasonDefinition("Winter", (12,1), (2,28), crossesYear: true)
        };

        // Holidays with a function to compute actual dates per year
        private static readonly List<Func<int, Guid, PromotionDefinition>> HolidayFactories = new()
        {
            year => CreateFixedDateHoliday("Valentine's Day", year, 2, 14),
            year => CreateChristmasHoliday(year),
            year => CreateEasterHoliday(year),
            year => CreateThanksgivingHoliday(year),
            year => CreateBlackFridayHoliday(year)
        };

        public static List<PromotionDefinition> GeneratePromotions(
            List<Store> stores,
            List<ProductCategory> categories,
            int years = 4)
        {
            var parentIds = categories
                .Where(c => c.ParentCategoryId == null)
                .Select(c => c.ProductCategoryId)
                .ToList();

            var promotions = new List<PromotionDefinition>();
            var rng = new Random();

            foreach (var store in stores)
            {
                bool southern = Constants.LocationData.SouthernHemisphereCountries.Contains(store.Country);
                for (int y = 0; y < years; y++)
                {
                    int year = store.OpenDate.Year + y;

                    // Seasonal promotions
                    foreach (var def in Seasons)
                    {
                        var (start, end) = def.GetDatesForHemisphere(year, southern);
                        if (end < store.OpenDate) continue;
                        if (start < store.OpenDate) start = store.OpenDate;
                        var name = southern && def.UsName != null && store.Country == "United States"
                            ? def.UsName
                            : def.Name;
                        promotions.Add(CreatePromotion(store.StoreId, name + " Sale " + year, start, end, parentIds, rng));
                    }

                    // Holiday promotions
                    foreach (var factory in HolidayFactories)
                    {
                        var promo = factory(year);
                        promo.StoreId = store.StoreId;
                        if (promo.EndDate < store.OpenDate) continue;
                        if (promo.StartDate < store.OpenDate) promo.StartDate = store.OpenDate;
                        promotions.Add(promo);
                    }
                }
            }
            // Remove overlaps and sort
            return promotions
                .GroupBy(p => (p.StoreId, p.Name, p.StartDate.Year))
                .SelectMany(g => g.OrderBy(p => p.StartDate))
                .ToList();
        }

        private static PromotionDefinition CreatePromotion(
            Guid storeId,
            string name,
            DateTime start,
            DateTime end,
            List<Guid> parentIds,
            Random rng)
        {
            return new PromotionDefinition
            {
                PromotionId = Guid.NewGuid(),
                StoreId = storeId,
                Name = name,
                StartDate = start,
                EndDate = end,
                TargetParentCategoryIds = parentIds,
                SampleRatio = 1.0,
                DiscountPercent = (decimal)(rng.NextDouble() * 0.2 + 0.1)
            };
        }

        private static PromotionDefinition CreateFixedDateHoliday(string name, int year, int month, int day)
        {
            return new PromotionDefinition
            {
                PromotionId = Guid.NewGuid(),
                Name = name,
                StartDate = new DateTime(year, month, day),
                EndDate = new DateTime(year, month, day),
                TargetParentCategoryIds = new List<Guid>(),
                SampleRatio = 1.0,
                DiscountPercent = 0.15m
            };
        }

        private static PromotionDefinition CreateChristmasHoliday(int year)
        {
            return new PromotionDefinition
            {
                PromotionId = Guid.NewGuid(),
                Name = "Christmas Sale",
                StartDate = new DateTime(year, 12, 15),
                EndDate = new DateTime(year, 12, 31),
                TargetParentCategoryIds = new List<Guid>(),
                SampleRatio = 1.0,
                DiscountPercent = 0.25m
            };
        }

        private static PromotionDefinition CreateEasterHoliday(int year)
        {
            var easter = EasterCalculator.GetEasterDate(year);
            return new PromotionDefinition
            {
                PromotionId = Guid.NewGuid(),
                Name = "Easter Sale",
                StartDate = easter.AddDays(-2),  // Good Friday
                EndDate = easter.AddDays(1),     // Easter Monday
                TargetParentCategoryIds = new List<Guid>(),
                SampleRatio = 1.0,
                DiscountPercent = 0.20m
            };
        }

        private static PromotionDefinition CreateThanksgivingHoliday(int year)
        {
            // Fourth Thursday of November
            var nov1 = new DateTime(year, 11, 1);
            int offset = ((int)DayOfWeek.Thursday - (int)nov1.DayOfWeek + 7) % 7;
            var thanksgiving = nov1.AddDays(offset + 21);
            return new PromotionDefinition
            {
                PromotionId = Guid.NewGuid(),
                Name = "Thanksgiving Sale",
                StartDate = thanksgiving,
                EndDate = thanksgiving,
                TargetParentCategoryIds = new List<Guid>(),
                SampleRatio = 1.0,
                DiscountPercent = 0.20m
            };
        }

        private static PromotionDefinition CreateBlackFridayHoliday(int year)
        {
            // Day after Thanksgiving
            var thanksgiving = CreateThanksgivingHoliday(year).StartDate;
            var bf = thanksgiving.AddDays(1);
            return new PromotionDefinition
            {
                PromotionId = Guid.NewGuid(),
                Name = "Black Friday Sale",
                StartDate = bf,
                EndDate = bf,
                TargetParentCategoryIds = new List<Guid>(),
                SampleRatio = 1.0,
                DiscountPercent = 0.30m
            };
        }

        private record SeasonDefinition(
            string Name,
            (int Month, int Day) NorthStart,
            (int Month, int Day) NorthEnd,
            string UsName = null,
            bool CrossesYear = false)
        {
            public string Name { get; } = Name;
            public string UsName { get; } = UsName;
            public (int Month, int Day) StartDef => NorthStart;
            public (int Month, int Day) EndDef => NorthEnd;

            public (DateTime start, DateTime end) GetDatesForHemisphere(int year, bool southern)
            {
                var (sm, sd) = southern ? (NorthStart.Month + 6 > 12 ? NorthStart.Month - 6 : NorthStart.Month + 6, NorthStart.Day) : NorthStart;
                var (em, ed) = southern ? (NorthEnd.Month + 6 > 12 ? NorthEnd.Month - 6 : NorthEnd.Month + 6, NorthEnd.Day) : NorthEnd;
                var startYear = (!southern && sm < NorthStart.Month) || (southern && sm > NorthStart.Month) && CrossesYear ? year - 1 : year;
                var endYear = CrossesYear && em < sm ? year + 1 : year;
                var start = new DateTime(startYear, sm, sd);
                var end = new DateTime(endYear, em, ed);
                return (start, end);
            }
        }
    }
}
