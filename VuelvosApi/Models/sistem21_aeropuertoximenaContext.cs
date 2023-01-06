using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VuelvosApi.Models
{
    public partial class sistem21_aeropuertoximenaContext : DbContext
    {
        public sistem21_aeropuertoximenaContext()
        {
        }

        public sistem21_aeropuertoximenaContext(DbContextOptions<sistem21_aeropuertoximenaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vuelo> Vuelo { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.IdVuelo)
                    .HasName("PRIMARY");

                entity.ToTable("vuelo");

                entity.Property(e => e.IdVuelo).HasColumnType("int(11)");

                entity.Property(e => e.ClaveVuelo).HasMaxLength(50);

                entity.Property(e => e.Destino).HasMaxLength(50);

                entity.Property(e => e.Hora).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
