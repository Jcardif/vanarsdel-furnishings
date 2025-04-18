namespace VanArsdel.DataGenerator.Constants;

public static class LocationData
{
    public static readonly Dictionary<string, int> CityCounts = new()
    {
        ["London"] = 3,
        ["Johannesburg"] = 2,
        ["New York"] = 4,
        ["Tokyo"] = 1,
        ["Berlin"] = 2,
        ["Paris"] = 3,
        ["Los Angeles"] = 2,
        ["Chicago"] = 3,
        ["California"] = 2,
        ["Seattle"] = 3
    };

    public static readonly Dictionary<string, string> RegionMap = new()
    {
        ["London"] = "Europe",
        ["Berlin"] = "Europe",
        ["Paris"] = "Europe",
        ["New York"] = "North America",
        ["Los Angeles"] = "North America",
        ["Chicago"] = "North America",
        ["Seattle"] = "North America",
        ["California"] = "North America",
        ["Tokyo"] = "Asia",
        ["Johannesburg"] = "Africa"
    };

    public static readonly Dictionary<string, string> Locales = new()
    {
        ["London"] = "en_GB",
        ["Johannesburg"] = "en_ZA",
        ["New York"] = "en_US",
        ["Tokyo"] = "ja",
        ["Berlin"] = "de",
        ["Paris"] = "fr",
        ["Los Angeles"] = "en_US",
        ["Chicago"] = "en_US",
        ["California"] = "en_US",
        ["Seattle"] = "en_US"
    };

    public static readonly Dictionary<string, string> LocaleTimeZones = new()
    {
        ["en_GB"] = "GMT Standard Time",
        ["en_US"] = "Pacific Standard Time",
        ["ja"] = "Tokyo Standard Time",
        ["de"] = "W. Europe Standard Time",
        ["fr"] = "Romance Standard Time",
        ["en_ZA"] = "South Africa Standard Time"
    };

    public static readonly Dictionary<string, string> CountryMap = new()
    {
        ["London"] = "United Kingdom",
        ["Johannesburg"] = "South Africa",
        ["New York"] = "United States",
        ["Tokyo"] = "Japan",
        ["Berlin"] = "Germany",
        ["Paris"] = "France",
        ["Los Angeles"] = "United States",
        ["Chicago"] = "United States",
        ["California"] = "United States",
        ["Seattle"] = "United States"
    };
    
    public static readonly Dictionary<string, string> CurrencyCountryMap = new()
    {
        ["United States"]  = "USD",
        ["United Kingdom"] = "GBP",
        ["Germany"]        = "EUR",
        ["France"]         = "EUR",
        ["Japan"]          = "JPY",
        ["South Africa"]   = "ZAR"
    };

    public static string GetCityLocale(string city)
    {
        if (Locales.TryGetValue(city, out var locale)) return locale;

        throw new ArgumentException($"City '{city}' not found in locales.");
    }
    
    
    public static string GetCountryLocale(string country)
    {
        var city = CountryMap.FirstOrDefault(kv => kv.Value == country).Key;
        if(string.IsNullOrEmpty(city))
            throw new ArgumentException($"Country '{country}' not found.");

        return GetCityLocale(city);
    }
    
    public static string GetRegionByCountry(string country)
    {
        var city = CountryMap.FirstOrDefault(kv => kv.Value == country).Key;
        if(string.IsNullOrEmpty(city))
            throw new ArgumentException($"Country '{country}' not found.");

        if (RegionMap.TryGetValue(city, out var region)) return region;
        throw new ArgumentException($"City '{city}' not found in regions.");
    }
}