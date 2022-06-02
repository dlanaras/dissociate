using System;
using Microsoft.EntityFrameworkCore;
using Dissociate.Models;

namespace Dissociate.Contexts
{
    public class DissociateContext : DbContext
    {
        public DissociateContext(DbContextOptions<DissociateContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<AccountMessage> AccountMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Blog>()
            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountMessages)
                .WithOne(am => am.Account)
                .HasForeignKey(am => am.AccountId);

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.UserName)
                .IsUnique();

            modelBuilder.Entity<Message>()
                .HasOne(m => m.AccountMessage)
                .WithOne(am => am.Message)
                .HasForeignKey(am => am.MessageId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Friends)
                .WithMany(a => a.Friends)
                .Map(m =>
                {
                    m.ToTable("AccountFriends");
                    m.MapLeftKey("AccountId");
                    m.MapRightKey("FriendId");
                });
        }
    }
}