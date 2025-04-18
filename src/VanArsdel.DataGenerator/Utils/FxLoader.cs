using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace VanArsdel.DataGenerator.Utils;

internal static class FxLoader
{
    private sealed class FxRow
    {
        public string  Month   { get; set; }
        [Name("GBP/USD")] public decimal GbpUsd { get; set; }
        [Name("JPY/USD")] public decimal JpyUsd { get; set; }
        [Name("ZAR/USD")] public decimal ZarUsd { get; set; }
        [Name("EUR/USD")] public decimal EurUsd { get; set; }
    }
    
    public static Dictionary<string, Dictionary<string, decimal>> Load(string path)
    {
        var cfg = new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true };
        using var reader = new StreamReader(path);
        using var csv    = new CsvReader(reader, cfg);
        var rows = csv.GetRecords<FxRow>().ToList();

        var table = new Dictionary<string, Dictionary<string, decimal>>();
        foreach (var r in rows)
        {
            string ym = DateTime.ParseExact(r.Month, "MMM yyyy", null).ToString("yyyy-MM");
            table[ym] = new Dictionary<string, decimal>
            {
                ["USD"] = 1m,
                ["GBP"] = r.GbpUsd,
                ["JPY"] = r.JpyUsd,
                ["ZAR"] = r.ZarUsd,
                ["EUR"] = r.EurUsd
            };
        }
        return table;
    }

}