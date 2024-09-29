
using CaseStudy.Entities;
using CaseStudy.Services.Interfaces;

namespace CaseStudy.Services
{
    public class Akbank : IBank
    {
        public async Task<Transaction> Pay(Transaction transaction)
        {
            // Akbank için ödeme işlemleri
            transaction.Status = "Success"; // Ödeme başarılı
            return await Task.FromResult(transaction);
        }

        public async Task<Transaction> Cancel(Transaction transaction)
        {
            // Akbank için iptal işlemleri
            transaction.Status = "Success"; // İptal başarılı
            return await Task.FromResult(transaction);
        }

        public async Task<Transaction> Refund(Transaction transaction)
        {
            // Akbank için geri ödeme işlemleri
            transaction.Status = "Success"; // Geri ödeme başarılı
            return await Task.FromResult(transaction);
        }
    }

}
