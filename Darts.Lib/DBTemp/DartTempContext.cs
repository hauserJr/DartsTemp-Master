using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Darts.Lib.DBTemp
{
    public partial class DartTempContext : DbContext
    {
        public DartTempContext()
        {
        }

        public DartTempContext(DbContextOptions<DartTempContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysAccount> SysAccount { get; set; }
        public virtual DbSet<Temp> Temp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=DartTemp;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysAccount>(entity =>
            {
                entity.Property(e => e.UserAccount).HasMaxLength(50);

                entity.Property(e => e.UserPwd).HasMaxLength(50);
            });

            modelBuilder.Entity<Temp>(entity =>
            {
                entity.Property(e => e.TempA).HasMaxLength(50);

                entity.Property(e => e.TempB).HasMaxLength(50);
            });
        }
    }
}
