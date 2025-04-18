namespace VanArsdel.DataGenerator.Domains.Retail;

public class ProductCatalog
{
    public Guid ProductId { get; init; }
    public string Name { get; init; } 
    public string? Brand { get; init; }
    public Guid CategoryId { get; init; }
    public string? Material { get; init; }
}