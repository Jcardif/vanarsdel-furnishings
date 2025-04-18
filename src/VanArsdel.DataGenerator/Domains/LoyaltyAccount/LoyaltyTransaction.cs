namespace VanArsdel.DataGenerator.Domains.LoyaltyAccount;

public class LoyaltyTransaction
{
    public Guid LoyaltyTxId { get; init; }
    public Guid AccountId { get; init; }
    public DateOnly TransactionDate { get; init; }
    public LoyaltyTxType TransactionType { get; init; }
    public int Points { get; init; }
    public string? Description { get; init; }
}