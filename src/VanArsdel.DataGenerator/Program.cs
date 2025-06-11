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
var (customerProfiles, loyaltyAccounts) = GenerateCustomerProfiles(stores);
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

// Save data split by country
AnsiConsole.MarkupLine("[bold yellow]Saving stores by country...[/]");
await CountryBasedCsvFileWriter.WriteAsync(stores, outDir, "Stores", "stores.csv", store => store.Country);
AnsiConsole.MarkupLine("[green]Saved stores by country[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving customer profiles by country...[/]");
await CountryBasedCsvFileWriter.WriteStoreBasedAsync(customerProfiles, stores, outDir, "CustomerProfiles", "customer_profiles.csv",
    profile => profile.StoreRefId);
AnsiConsole.MarkupLine("[green]Saved customer profiles by country[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving loyalty accounts by country...[/]");
// Create a lookup from CustomerId to StoreRefId to determine country
var customerToStore = customerProfiles.ToDictionary(cp => cp.CustomerId, cp => cp.StoreRefId);
await CountryBasedCsvFileWriter.WriteStoreBasedAsync(loyaltyAccounts, stores, outDir, "LoyaltyAccounts", "loyalty_accounts.csv",
    account => customerToStore.TryGetValue(account.CustomerId, out var storeId) ? storeId : Guid.Empty);
AnsiConsole.MarkupLine("[green]Saved loyalty accounts by country[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving supplier profiles by country...[/]");
await CountryBasedCsvFileWriter.WriteAsync(supplierProfiles, outDir, "SupplierProfiles", "supplier_profiles.csv",
    supplier => supplier.Country);
AnsiConsole.MarkupLine("[green]Saved supplier profiles by country[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving product categories...[/]");
await CountryBasedCsvFileWriter.WriteProductBasedAsync(categories, outDir, "ProductCategories", "product_categories.csv");
AnsiConsole.MarkupLine("[green]Saved product categories[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving product catalog...[/]");
await CountryBasedCsvFileWriter.WriteProductBasedAsync(products, outDir, "ProductCatalog", "product_catalog.csv");
AnsiConsole.MarkupLine("[green]Saved product catalog[/]");

AnsiConsole.MarkupLine("[bold yellow]Saving inventories by country...[/]");
await CountryBasedCsvFileWriter.WriteStoreBasedAsync(inventories, stores, outDir, "Inventories", "inventories.csv",
    inventory => inventory.StoreId);
AnsiConsole.MarkupLine("[green]Saved inventories by country[/]");

AnsiConsole.MarkupLine("[bold lime]All done![/]");


