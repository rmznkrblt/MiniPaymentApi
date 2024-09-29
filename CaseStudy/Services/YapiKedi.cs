using CaseStudy.Entities;
using CaseStudy.Services.Interfaces;

namespace CaseStudy.Services
{
    public class YapiKredi : IBank
    {
        public async Task<Transaction> Pay(Transaction transaction)
        {
            // YapiKredi için ödeme işlemleri
            transaction.Status = "Success"; // Ödeme başarılı
            return await Task.FromResult(transaction);
        }

        public async Task<Transaction> Cancel(Transaction transaction)
        {
            // YapiKredi için iptal işlemleri
            transaction.Status = "Success"; // İptal başarılı
            return await Task.FromResult(transaction);
        }

        public async Task<Transaction> Refund(Transaction transaction)
        {
            // YapiKredi için geri ödeme işlemleri
            transaction.Status = "Success"; // Geri ödeme başarılı
            return await Task.FromResult(transaction);
        }
    }
}
