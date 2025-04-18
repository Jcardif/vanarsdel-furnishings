using Bogus;
using VanArsdel.DataGenerator.Domains.Retail;

namespace VanArsdel.DataGenerator.Generators;

public static class StoreGenerator
{
    public static List<Store> GenerateStores(DateTime businessStartDate)
    {
        int[] launchMonths = [3, 6, 9, 12];
        const int totalYears = 3;
        const int quarters = 4;
        var totalQuarterSlots = totalYears * quarters;


        var stores = new List<Store>();

        foreach (var kv in CityCounts)
        {
            var city = kv.Key;
            var count = kv.Value;
            var locale = Locales[city];
            var country = CountryMap[city];

            var faker = new Faker(locale);
            var address = faker.Address;

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(LocaleTimeZones[locale]);

            for (var i = 0; i < count; i++)
            {
                DateTime storeOpenDate;

                // The first store in each city opened on the first day of business
                if (i == 0)
                {
                    storeOpenDate = TimeZoneInfo.ConvertTime(
                        new DateTime(
                            businessStartDate.Year,
                            businessStartDate.Month,
                            businessStartDate.Day,
                            9, 0, 0,
                            DateTimeKind.Unspecified), timeZone);
                }
                else
                {
                    // Uniformly pick one of the 12 quarter slots
                    var quarterSlot = faker.Random.Int(0, totalQuarterSlots - 1);
                    var yearOff = quarterSlot / quarters;
                    var season = quarterSlot % quarters;
                    var month = launchMonths[season];
                    var year = businessStartDate.Year + yearOff;
                    var day = faker.Random.Int(1, DateTime.DaysInMonth(year, month));
                    storeOpenDate = TimeZoneInfo.ConvertTime(
                        new DateTime(year, month, day, 9, 0, 0,
                            DateTimeKind.Unspecified), timeZone);
                }

                stores.Add(new Store()
                {
                    StoreId = Guid.NewGuid(),
                    Name = count != 1 ? $"VanArsdel {address.StreetName()} {city}" : $"VanArsdel {city}",
                    Region = RegionMap[city],
                    City = city,
                    Address = $"{address.StreetAddress()} {city} {country}",
                    Country = country,
                    OpenDate = storeOpenDate
                });
            }
        }

        return stores;
    }
}