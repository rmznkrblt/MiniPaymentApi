using CaseStudy.Entities;

namespace CaseStudy.Services.Interfaces
{
    
    public interface IBank
    {
        Task<Transaction> Pay(Transaction transaction);
        Task<Transaction> Cancel(Transaction transaction);
        Task<Transaction> Refund(Transaction transaction);
    }


}
