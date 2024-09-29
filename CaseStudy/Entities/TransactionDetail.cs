namespace CaseStudy.Entities
{
    public class TransactionDetail
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public string TransactionType { get; set; } // Sale, Refund, Cancel
        public string Status { get; set; } // Success, Fail
        public decimal Amount { get; set; }
    }
}
