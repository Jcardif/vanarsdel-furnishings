using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace VanArsdel.DataGenerator.Utils;

public static class CountryBasedCsvFileWriter
{
    public static async Task WriteAsync<T>(IEnumerable<T> records, string baseOutputDir, string dataTypeFolder,
        string baseFileName, Func<T, string> countrySelector, char delimiter = ',')
    {
        // Group records by country
        var recordsByCountry = records.GroupBy(countrySelector);

        // Create data type specific directory (e.g., CustomerProfiles, Stores, etc.)
        var dataTypeDir = Path.Combine(baseOutputDir, dataTypeFolder);
        Directory.CreateDirectory(dataTypeDir);

        var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = delimiter.ToString()
        };

        foreach (var countryGroup in recordsByCountry)
        {
            var country = countryGroup.Key;
            var countryRecords = countryGroup.ToList();

            // Create file name with country suffix (e.g., stores_USA.csv, stores_Canada.csv)
            var fileNameWithCountry = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{SanitizeFileName(country)}.csv";
            var filePath = Path.Combine(dataTypeDir, fileNameWithCountry);

            // Write the CSV file
            await using var writer = new StreamWriter(filePath);
            await using var csv = new CsvWriter(writer, cfg);
            await csv.WriteRecordsAsync(countryRecords);
        }
    }

    public static async Task WriteStoreBasedAsync<T>(IEnumerable<T> records, List<Store> stores,
        string baseOutputDir, string dataTypeFolder, string baseFileName, Func<T, Guid> storeIdSelector, char delimiter = ',')
    {
        // Create a lookup from StoreId to Country
        var storeToCountry = stores.ToDictionary(s => s.StoreId, s => s.Country);

        // Group records by country using store lookup
        var recordsByCountry = records.GroupBy(record =>
        {
            var storeId = storeIdSelector(record);
            return storeToCountry.TryGetValue(storeId, out var country) ? country : "Unknown";
        });

        // Create data type specific directory (e.g., CustomerProfiles, LoyaltyAccounts, etc.)
        var dataTypeDir = Path.Combine(baseOutputDir, dataTypeFolder);
        Directory.CreateDirectory(dataTypeDir);

        var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = delimiter.ToString()
        };

        foreach (var countryGroup in recordsByCountry)
        {
            var country = countryGroup.Key;
            var countryRecords = countryGroup.ToList();

            // Skip unknown countries
            if (country == "Unknown") continue;

            // Create file name with country suffix (e.g., customer_profiles_USA.csv, customer_profiles_Canada.csv)
            var fileNameWithCountry = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{SanitizeFileName(country)}.csv";
            var filePath = Path.Combine(dataTypeDir, fileNameWithCountry);

            // Write the CSV file
            await using var writer = new StreamWriter(filePath);
            await using var csv = new CsvWriter(writer, cfg);
            await csv.WriteRecordsAsync(countryRecords);
        }
    }

    public static async Task WriteProductBasedAsync<T>(IEnumerable<T> records, string baseOutputDir,
        string dataTypeFolder, string fileName, char delimiter = ',')
    {
        // For product-related data that doesn't have country info, we'll save in a data type folder
        var dataTypeDir = Path.Combine(baseOutputDir, dataTypeFolder);
        Directory.CreateDirectory(dataTypeDir);

        var filePath = Path.Combine(dataTypeDir, fileName);

        var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = delimiter.ToString()
        };

        await using var writer = new StreamWriter(filePath);
        await using var csv = new CsvWriter(writer, cfg);
        await csv.WriteRecordsAsync(records);
    }

    private static string SanitizeFileName(string name)
    {
        // Replace invalid file name characters with underscores
        var invalidChars = Path.GetInvalidFileNameChars();
        return invalidChars.Aggregate(name, (current, c) => current.Replace(c, '_'));
    }
}
