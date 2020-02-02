using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tradelink.Persistence.Models;

namespace Tradelink.Persistence.Context
{
    public partial class TradelinkContext : DbContext
    {
        public TradelinkContext()
        {
        }

        public TradelinkContext(DbContextOptions<TradelinkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authorities> Authorities { get; set; }
        public virtual DbSet<Authority> Authority { get; set; }
        public virtual DbSet<HibernateSequence> HibernateSequence { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=eazi4u;user=root;pwd=password", x => x.ServerVersion("5.7.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authorities>(entity =>
            {
                entity.ToTable("authorities");

                entity.HasIndex(e => e.Username)
                    .HasName("UK_baahryprcge2u172egph1qwur")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Authority)
                    .HasColumnName("authority")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Authority>(entity =>
            {
                entity.ToTable("authority");

                entity.HasIndex(e => e.Username)
                    .HasName("UK_39j00qgxdxu7gyd5dgv2ucahf")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Authority1)
                    .HasColumnName("authority")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<HibernateSequence>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hibernate_sequence");

                entity.Property(e => e.NextVal)
                    .HasColumnName("next_val")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.HasIndex(e => e.RoleId)
                    .HasName("FKa68196081fvovjhkek5m97n3y");

                entity.HasIndex(e => e.UserId)
                    .HasName("FKj345gk1bovqvfame88rcx7yyx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKa68196081fvovjhkek5m97n3y");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKj345gk1bovqvfame88rcx7yyx");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Username)
                    .HasName("UK_r43af9ap4edm43mmtq01oddj6")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
