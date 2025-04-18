namespace VanArsdel.DataGenerator.Domains.Retail;

public class ProductCategory
{
    public Guid ProductCategoryId { get; init; }
    public Guid? ParentCategoryId { get; init; }
    public string Name { get; init; } = default!;
}