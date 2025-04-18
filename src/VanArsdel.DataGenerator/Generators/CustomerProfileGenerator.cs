using System.Collections.Concurrent;
using Bogus;
using VanArsdel.DataGenerator.Domains.Profiles;
using VanArsdel.DataGenerator.Domains.Retail;

namespace VanArsdel.DataGenerator.Generators;

public static class CustomerProfileGenerator
{
    private static readonly string[] DelimiterItems = { ".", "_", "-", "" };

    public static List<CustomerProfile> GenerateCustomerProfiles(List<Store> stores,
        int basePerStore = 160_000,
        double annualGrowthRate = 0.15)
    {
        var profiles = new ConcurrentBag<CustomerProfile>();
        
        // track all generated emails to prevent duplicates
        var usedEmails = new ConcurrentDictionary<string, byte>();

        const int years = 4;

        // precompute per-store per-year customer counts
        var storeYearCounts = stores.ToDictionary(
            s => s.StoreId,
            _ =>
            {
                var counts = new int[years];
                for (var y = 0; y < years; y++)
                    counts[y] = (int)Math.Round(basePerStore * Math.Pow(1 + annualGrowthRate, y));
                return counts;
            });

        Parallel.ForEach(stores, store =>
        {
            var locale = GetCityLocale(store.City);

            var faker = new Bogus.Faker(locale);

            for (var yearIndex = 0; yearIndex < years; yearIndex++)
            {
                // define the store start window clamped at its open date
                var yearStart = store.OpenDate.AddYears(yearIndex);
                var yearEnd = yearStart.AddYears(1).AddDays(-1);

                var countThisYear = storeYearCounts[store.StoreId][yearIndex];

                // Use a local list to reduce contention on the ConcurrentBag
                var localProfiles = new List<CustomerProfile>(countThisYear);

                for (var i = 0; i < countThisYear; i++)
                {
                    // ensure the date join is not before the store open date
                    var windowStart = yearStart < store.OpenDate ? store.OpenDate : yearStart;
                    var joinDate = DateOnly.FromDateTime(faker.Date.Between(windowStart, yearEnd));
                    
                    var firstName = faker.Name.FirstName();
                    var lastName = faker.Name.LastName();
                    var domain = faker.Internet.Email().Split('@')[1];

                    // Generate a unique email address
                    string email;
                    do
                    {
                        var emailDelimiter = faker.PickRandom(DelimiterItems);
                        var suffix = faker.PickRandom(new List<string> { "", faker.Random.AlphaNumeric(4) });
                        email = $"{firstName.ToLower()}{emailDelimiter}{lastName.ToLower()}{suffix}@{domain}".ToLower();
                    } while (!usedEmails.TryAdd(email, 0));
                

                    localProfiles.Add(new CustomerProfile()
                    {
                        CustomerId = Guid.NewGuid(),
                        StoreRefId = store.StoreId,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        JoinDate = joinDate
                    });
                }

                // Add local batch to the concurrent bag
                foreach (var profile in localProfiles)
                    profiles.Add(profile);

            }
        });

        return profiles.ToList();
    }
}