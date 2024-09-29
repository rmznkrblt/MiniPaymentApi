
using CaseStudy.Data;
using CaseStudy.Entities;
using CaseStudy.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Services
{

    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _context.Transactions.Include(t => t.TransactionDetails)
                                               .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.Include(t => t.TransactionDetails).ToListAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
    }


}
