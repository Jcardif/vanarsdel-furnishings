using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace VanArsdel.DataGenerator.Utils;

public static class CsvFileWriter
{
    public static async Task WriteAsync<T>(IEnumerable<T> records, string path, char delimiter = ',')
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);

        var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = delimiter.ToString()
        };

        await using var writer = new StreamWriter(path);
        await using var csv = new CsvWriter(writer, cfg);
        await csv.WriteRecordsAsync(records);
    }
}