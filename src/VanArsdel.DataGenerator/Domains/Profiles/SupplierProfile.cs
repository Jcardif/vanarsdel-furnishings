namespace VanArsdel.DataGenerator.Domains.Profiles;

public class SupplierProfile
{
    public Guid SupplierId { get; init; }
    public string Name { get; init; } = default!;
    public string Region { get; init; } = default!;
    public string Country { get; init; } = default!;
    public double ReliabilityScore { get; init; }
    public string Phone { get; init; } = default!;
    public string Address { get; init; } = default!;
}