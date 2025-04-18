using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace VanArsdel.DataGenerator.Utils;

public class CsvFileReader
{
    public static List<T> Read<T>(string path, char delimiter = ',')
    {
        var cfg = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter       = delimiter.ToString()
        };

        using var reader = new StreamReader(path);
        using var csv    = new CsvReader(reader, cfg);
        return csv.GetRecords<T>().ToList();
    }
}