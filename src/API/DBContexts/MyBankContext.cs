using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models {
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
         modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

         modelBuilder.Entity<Transaction>(entity => {
            entity.Property(e => e.Date).HasColumnType("date");
         });

         modelBuilder.Entity<Account>(entity => {
            entity.Property(e => e.Balance)
                .IsRequired();
         });

         modelBuilder.Entity<Customer>(entity => {
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
         });
      }
   }
}
