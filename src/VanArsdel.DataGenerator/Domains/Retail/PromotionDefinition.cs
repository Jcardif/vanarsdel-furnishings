namespace VanArsdel.DataGenerator.Domains.Retail;

public class PromotionDefinition
{
    public Guid PromotionId { get; init; }
    public Guid StoreId { get; init; }
    public string Name { get; init; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Guid> TargetParentCategoryIds { get; init; } = new();
    public double SampleRatio { get; init; }
    public decimal DiscountPercent { get; init; }
}