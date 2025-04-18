using Microsoft.Extensions.Configuration;
using VanArsdel.DataGenerator.Generators;
using Spectre.Console;

AnsiConsole.Write(new FigletText("VanArsdel Furnishings DataGen").Centered().Color(Color.Cyan1));

var from = new DateOnly(2021, 1, 1);
var fxCsvPath = Path.Combine(AppContext.BaseDirectory, "Assets", "fx.csv");


// compute project root two levels up from bin/
var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
var outDir = Path.Combine(projectRoot, "Output");

AnsiConsole.MarkupLine("[bold yellow]Generating store data...[/]");
var stores = GenerateStores(from.ToDateTime(new TimeOnly()));
AnsiConsole.MarkupLine($"[green]Generated {stores.Count} stores[/]");

AnsiConsole.MarkupLine("[bold yellow]Generating customer profiles...[/]");
var customerProfiles = GenerateCustomerProfiles(stores);
AnsiConsole.MarkupLine($"[green]Generated {customerProfiles.Count} customer profiles[/]");

AnsiConsole.MarkupLine("[bold yellow]Generating supplier profiles...[/]");
var supplierProfiles = GenerateSupplierProfiles();
AnsiConsole.MarkupLine($"[green]Generated {supplierProfiles.Count} supplier profiles[/]");

AnsiConsole.MarkupLine("[bold yellow]Generating product categories...[/]");
var categories = GenerateProductCategories();
AnsiConsole.MarkupLine($"[green]Generated {categories.Count} product categories[/]");

AnsiConsole.MarkupLine("[bold yellow]Generating product catalog...[/]");
var products = ProductCatalogGenerator.GenerateProductCatalog(categories);
AnsiConsole.MarkupLine($"[green]Generated {products.Count} products[/]");

AnsiConsole.MarkupLine("[bold yellow]Generating inventories...[/]");
var inventories = InventoryGenerator.GenerateInventories(stores, categories, products, supplierProfiles, fxCsvPath);
AnsiConsole.MarkupLine($"[green]Generated {inventories.Count} inventories[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving stores.csv...[/]");
await CsvFileWriter.WriteAsync(stores, Path.Combine(outDir, "stores.csv"));
AnsiConsole.MarkupLine("[green]Saved stores.csv[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving customer_profiles.csv...[/]");
await CsvFileWriter.WriteAsync(customerProfiles, Path.Combine(outDir, "customer_profiles.csv"));
AnsiConsole.MarkupLine("[green]Saved customer_profiles.csv[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving supplier_profiles.csv...[/]");
await CsvFileWriter.WriteAsync(supplierProfiles, Path.Combine(outDir, "supplier_profiles.csv"));
AnsiConsole.MarkupLine("[green]Saved supplier_profiles.csv[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving product_categories.csv...[/]");
await CsvFileWriter.WriteAsync(categories, Path.Combine(outDir, "product_categories.csv"));
AnsiConsole.MarkupLine("[green]Saved product_categories.csv[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving product_catalog.csv...[/]");
await CsvFileWriter.WriteAsync(products, Path.Combine(outDir, "product_catalog.csv"));
AnsiConsole.MarkupLine("[green]Saved product_catalog.csv[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving inventories.csv...[/]");
await CsvFileWriter.WriteAsync(inventories, Path.Combine(outDir, "inventories.csv"));
AnsiConsole.MarkupLine("[green]Saved inventories.csv[/]");

AnsiConsole.MarkupLine("[bold lime]All done![/]");


