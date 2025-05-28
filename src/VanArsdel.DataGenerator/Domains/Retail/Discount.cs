namespace VanArsdel.DataGenerator.Domains.Retail;

public class Discount
{
    public Guid DiscountId { get; init; }
    public Guid ProductId { get; init; }
    public decimal Value { get; init; }
    public decimal ValueInUsd { get; init; }
    public string Currency { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public Guid StoreId { get; init; }
}