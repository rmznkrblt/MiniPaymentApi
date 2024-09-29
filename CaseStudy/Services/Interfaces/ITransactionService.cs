
using CaseStudy.Entities;

namespace CaseStudy.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> PayAsync(Transaction transaction);
        Task<Transaction> CancelAsync(Guid transactionId);
        Task<Transaction> RefundAsync(Guid transactionId);
        Task<Transaction> GetByIdAsync(Guid id);
    }

}
