namespace CaseStudy.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string BankId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string Status { get; set; } // Success, Fail
        public string OrderReference { get; set; }
        public DateTime TransactionDate { get; set; }
        public ICollection<TransactionDetail> TransactionDetails { get; set; }
    }

}
