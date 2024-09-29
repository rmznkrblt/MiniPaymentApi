using CaseStudy.Entities;

namespace CaseStudy.Services.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddAsync(Transaction transaction); // Yeni bir işlem ekler
        Task<Transaction> GetByIdAsync(Guid id); // Belirli bir ID'ye sahip işlemi getirir
        Task<List<Transaction>> GetAllAsync(); // Tüm işlemleri getirir
        Task UpdateAsync(Transaction transaction); // Var olan işlemi günceller
        Task DeleteAsync(Guid id); // Belirli bir ID'ye sahip işlemi siler

    }

}
