using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FreakyFashionServices.Catalog.Models
{
    public partial class FreakyFashionServicesBasketContext : DbContext
    {
        public FreakyFashionServicesBasketContext()
        {
        }

        public FreakyFashionServicesBasketContext(DbContextOptions<FreakyFashionServicesBasketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
