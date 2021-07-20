using Microsoft.EntityFrameworkCore;
using System;

#nullable disable

namespace TestDB
{
    public partial class TestDBcontext : DbContext
    {
        public TestDBcontext()
        {
        }

        public TestDBcontext(DbContextOptions<TestDBcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<CPSorder> CPSorders { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("options not configured");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<CPSorder>(entity =>
            {
                entity.HasOne(d => d.CPSchargePartner)
                    .WithMany(p => p.CPSorders)
                    .HasForeignKey(d => d.CPSchargePartnerID)
                    .HasConstraintName("FK_CPSorders_Partners");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.Property(e => e.PartnerName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}