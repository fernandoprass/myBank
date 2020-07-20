using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class MyBankContext : DbContext {
      public MyBankContext() {
      }

      public MyBankContext(DbContextOptions<MyBankContext> options)
          : base(options) {
      }

      public virtual DbSet<Transaction> Transaction { get; set; }
      public virtual DbSet<Account> Account { get; set; }
      public virtual DbSet<Customer> Patient { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {

      }
   }
}
