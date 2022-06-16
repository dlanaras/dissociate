using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Dissociate.Models;

namespace Dissociate.Contexts
{
    public partial class DissociateContext : DbContext
    {
        public DissociateContext()
        {
        }

        public DissociateContext(DbContextOptions<DissociateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblMessage> TblMessages { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=pma;password=pmapass;database=dissociate", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.7.3-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TblMessage>(entity =>
            {
                entity.HasKey(e => new { e.IdReceiveUser, e.IdSendUser })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("tbl_messages");

                entity.HasIndex(e => e.IdReceiveUser, "fk_tbl_user_has_tbl_user_tbl_user2_idx");

                entity.HasIndex(e => e.IdSendUser, "fk_tbl_user_has_tbl_user_tbl_user3_idx");

                entity.Property(e => e.IdReceiveUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_receiveUser");

                entity.Property(e => e.IdSendUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_sendUser");

                entity.Property(e => e.MessageContent)
                    .HasMaxLength(45)
                    .HasColumnName("messageContent");

                entity.Property(e => e.SendTime)
                    .HasColumnType("datetime")
                    .HasColumnName("sendTime");

                entity.HasOne(d => d.IdReceiveUserNavigation)
                    .WithMany(p => p.TblMessageIdReceiveUserNavigations)
                    .HasForeignKey(d => d.IdReceiveUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tbl_messages_ibfk_1");

                entity.HasOne(d => d.IdSendUserNavigation)
                    .WithMany(p => p.TblMessageIdSendUserNavigations)
                    .HasForeignKey(d => d.IdSendUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tbl_messages_ibfk_2");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_user");

                entity.HasIndex(e => e.Email, "email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("username");

                entity.HasMany(d => d.IdFriends)
                    .WithMany(p => p.IdUsers)
                    .UsingEntity<Dictionary<string, object>>(
                        "TblFriendaccount",
                        l => l.HasOne<TblUser>().WithMany().HasForeignKey("IdFriend").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("tbl_friendaccount_ibfk_2"),
                        r => r.HasOne<TblUser>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("tbl_friendaccount_ibfk_1"),
                        j =>
                        {
                            j.HasKey("IdUser", "IdFriend").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("tbl_friendaccount");

                            j.HasIndex(new[] { "IdFriend" }, "fk_tbl_user_has_tbl_user_tbl_user1_idx");

                            j.HasIndex(new[] { "IdUser" }, "fk_tbl_user_has_tbl_user_tbl_user_idx");

                            j.IndexerProperty<int>("IdUser").HasColumnType("int(11)").HasColumnName("id_user");

                            j.IndexerProperty<int>("IdFriend").HasColumnType("int(11)").HasColumnName("id_friend");
                        });

                entity.HasMany(d => d.IdUsers)
                    .WithMany(p => p.IdFriends)
                    .UsingEntity<Dictionary<string, object>>(
                        "TblFriendaccount",
                        l => l.HasOne<TblUser>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("tbl_friendaccount_ibfk_1"),
                        r => r.HasOne<TblUser>().WithMany().HasForeignKey("IdFriend").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("tbl_friendaccount_ibfk_2"),
                        j =>
                        {
                            j.HasKey("IdUser", "IdFriend").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("tbl_friendaccount");

                            j.HasIndex(new[] { "IdFriend" }, "fk_tbl_user_has_tbl_user_tbl_user1_idx");

                            j.HasIndex(new[] { "IdUser" }, "fk_tbl_user_has_tbl_user_tbl_user_idx");

                            j.IndexerProperty<int>("IdUser").HasColumnType("int(11)").HasColumnName("id_user");

                            j.IndexerProperty<int>("IdFriend").HasColumnType("int(11)").HasColumnName("id_friend");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
