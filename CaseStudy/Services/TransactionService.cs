
using CaseStudy.Entities;
using CaseStudy.Services.Interfaces;

namespace CaseStudy.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly BankServiceFactory _bankServiceFactory;

        public TransactionService(ITransactionRepository transactionRepository, BankServiceFactory bankServiceFactory)
        {
            _transactionRepository = transactionRepository;
            _bankServiceFactory = bankServiceFactory;
        }

        public async Task<Transaction> PayAsync(Transaction transaction)
        {
            var bankService = _bankServiceFactory.GetBankService(transaction.BankId);
            var processedTransaction = await bankService.Pay(transaction);
            return await _transactionRepository.AddAsync(processedTransaction);
        }

        public async Task<Transaction> CancelAsync(Guid transactionId)
        {
            var transaction = await _transactionRepository.GetByIdAsync(transactionId);
            if (transaction == null || transaction.TransactionDate.Date != DateTime.Now.Date)
            {
                throw new Exception("Cancel not allowed");
            }

            var bankService = _bankServiceFactory.GetBankService(transaction.BankId);
            return await bankService.Cancel(transaction);
        }

        public async Task<Transaction> RefundAsync(Guid transactionId)
        {
            var transaction = await _transactionRepository.GetByIdAsync(transactionId);
            if (transaction == null || (DateTime.Now - transaction.TransactionDate).TotalDays < 1)
            {
                throw new Exception("Refund not allowed");
            }

            var bankService = _bankServiceFactory.GetBankService(transaction.BankId);
            return await bankService.Refund(transaction);
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _transactionRepository.GetByIdAsync(id);
        }
    }



}
