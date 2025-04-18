namespace VanArsdel.DataGenerator.Domains.Retail;

public class Transaction
{
    public Guid TransactionId { get; init; }
    public Guid CustomerId { get; init; }
    public DateTime TransactionDate { get; init; }
    public decimal TotalAmount { get; init; }
    public decimal TotalAmountUsd { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
    public TransactionStatus Status { get; init; }
    public Guid StoreId { get; init; }
    public string Currency { get; init; }
}