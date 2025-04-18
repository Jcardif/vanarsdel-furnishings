using Bogus.DataSets;
using VanArsdel.DataGenerator.Domains.Profiles;

namespace VanArsdel.DataGenerator.Generators;

public static class SupplierProfileGenerator
{
    public static List<SupplierProfile> GenerateSupplierProfiles(int approximateSuppliers = 50)
    {
        //Build a map of country → total store‐count
        var storeCountsByCountry = new Dictionary<string, int>();
        foreach (var cityKvp in CityCounts)
        {
            var city    = cityKvp.Key;
            var stores  = cityKvp.Value;
            var country = CountryMap[city];

            if (!storeCountsByCountry.ContainsKey(country))
                storeCountsByCountry[country] = 0;

            storeCountsByCountry[country] += stores;
        }
        
        
        // get the total number of stores
        var totalStores = storeCountsByCountry.Values.Sum();
        
        
        // allocate suppliers to countries proportional to their store counts. 
        var suppliersByCountry = new Dictionary<string, int>();
        foreach (var kvp in storeCountsByCountry)
        {
            var country = kvp.Key;
            var storeCount = kvp.Value;

            // compute the supplier count for this country
            var supplierCount = (int)Math.Round((double)storeCount / totalStores * approximateSuppliers);

            suppliersByCountry[country] = supplierCount;
        }
        
        // generate the suppliers
        var suppliers = new List<SupplierProfile>();
        foreach (var kvp in suppliersByCountry)
        {
            var country = kvp.Key;
            var supplierCount = kvp.Value;
            var locale = GetCountryLocale(country);
            
            var faker = new Bogus.Faker(locale);
            
            // add in-house VanArsdel Home Supplier for each country
            suppliers.Add(new SupplierProfile()
            {
                SupplierId = Guid.NewGuid(),
                Name = "VanArsdel Home",
                Country = country,
                Region = GetRegionByCountry(country),
                ReliabilityScore = 0.987,
                Address = $"{faker.Address.StreetAddress()} {faker.Address.City()} {country}",
                Phone = faker.Phone.PhoneNumber(),
            });


            for (var i = 0; i < supplierCount; i++)
            {
                var address = new Address(locale);
                var company = new Company(locale);
            
                suppliers.Add(new SupplierProfile()
                {
                    SupplierId = Guid.NewGuid(),
                    Name = company.CompanyName(),
                    Country = country,
                    Region = GetRegionByCountry(country),
                    ReliabilityScore = Math.Round(faker.Random.Double(0.7, 0.99), 2),
                    Address =  $"{address.StreetAddress()} {address.City()} {country}",
                    Phone = faker.Phone.PhoneNumber(),
                });
            }
        }
        

        return suppliers;
    }
}