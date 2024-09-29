using CaseStudy.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Data
{   
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Transaction>()
                .HasMany(t => t.TransactionDetails)
                .WithOne()
                .HasForeignKey(td => td.TransactionId);
        }
    }
}
