namespace VanArsdel.DataGenerator.Domains.Retail;

public class Store
{
    public Guid StoreId { get; init; }
    public string Name { get; init; } = default!;
    public string Address { get; init; } = default!;
    public string City { get; init; } = default!;
    public string Country { get; init; } = default!;
    public string Region { get; init; } = default!;
    public DateTime OpenDate { get; init; }
}