namespace VanArsdel.DataGenerator.Domains.Profiles;

public class CustomerProfile
{
    public Guid CustomerId { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateOnly JoinDate { get; init; }
    public Guid StoreRefId { get; init; } // where the customer was first registered
}