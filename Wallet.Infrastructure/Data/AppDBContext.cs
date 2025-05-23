using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Modals;

namespace Wallet.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Modals.Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Wallet)
                .WithOne(x => x.User)
                .HasForeignKey<Domain.Modals.Wallet>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
