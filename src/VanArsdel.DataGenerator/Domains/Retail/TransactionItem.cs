namespace VanArsdel.DataGenerator.Domains.Retail;

public class TransactionItem
{
    public Guid TransactionItemId { get; init; }
    public Guid TransactionId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal UnitPriceUsd { get; init; }
    public Guid? DiscountApplied { get; init; }
}