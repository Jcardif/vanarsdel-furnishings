namespace VanArsdel.DataGenerator.Domains.LoyaltyAccount;

public class LoyaltyAccount
{
    public Guid AccountId { get; init; }
    public Guid CustomerId { get; init; }
    public string AccountNumber { get; init; }
    public DateOnly CreatedDate { get; init; }
    public int PointsBalance { get; set; }
}