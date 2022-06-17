using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbMadness.Models
{
    public partial class SpellBookContext : DbContext
    {
        public SpellBookContext()
        {
        }

        public SpellBookContext(DbContextOptions<SpellBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Creature> Creatures { get; set; } = null!;
        public virtual DbSet<RegisteredGoblin> RegisteredGoblins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-5H65PMP\\SQLEXPRESS01;Database=SpellBook;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creature>(entity =>
            {
                entity.Property(e => e.CreatureId).HasColumnName("CreatureID");

                entity.Property(e => e.Size)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisteredGoblin>(entity =>
            {
                entity.HasKey(e => e.GoblinId)
                    .HasName("PK__Register__1D3276B93877355F");

                entity.Property(e => e.GoblinId).HasColumnName("GoblinID");

                entity.Property(e => e.FavIcecreamFlavor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
