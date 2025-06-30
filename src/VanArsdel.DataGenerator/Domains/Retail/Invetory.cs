

namespace VanArsdel.DataGenerator.Domains.Retail;

public class Inventory
{
    public Guid InventoryId { get; init; }
    public Guid ProductId { get; init; }
    public Guid SupplierId { get; init; }
    public Guid StoreId { get; init; }
    public int StockQuantity { get; init; }
    public int ReorderLevel { get; init; }
    public decimal Price { get; init; }
    public decimal PriceUsd { get; init; }
    public required string CurrencyCode { get; init; }
    public DateTime LastReceived { get; init; }
}