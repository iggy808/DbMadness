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
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<FavoriteAnimal> FavoriteAnimals { get; set; } = null!;
        public virtual DbSet<FavoriteColor> FavoriteColors { get; set; } = null!;
        public virtual DbSet<FavoriteNumber> FavoriteNumbers { get; set; } = null!;
        public virtual DbSet<RegisteredGoblin> RegisteredGoblins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasIndex(e => e.Goblin, "UQ__Favorite__50D22630B5BF797E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnimalNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.Animal)
                    .HasConstraintName("FK__Favorites__Anima__5441852A");

                entity.HasOne(d => d.ColorNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.Color)
                    .HasConstraintName("FK__Favorites__Color__5535A963");

                entity.HasOne(d => d.GoblinNavigation)
                    .WithOne(p => p.Favorite)
                    .HasForeignKey<Favorite>(d => d.Goblin)
                    .HasConstraintName("FK__Favorites__Gobli__571DF1D5");

                entity.HasOne(d => d.NumberNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.Number)
                    .HasConstraintName("FK__Favorites__Numbe__5629CD9C");
            });

            modelBuilder.Entity<FavoriteAnimal>(entity =>
            {
                entity.ToTable("Favorite_Animals");

                entity.HasIndex(e => e.Value, "UQ__Favorite__07D9BBC23E9464CF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FavoriteColor>(entity =>
            {
                entity.ToTable("Favorite_Colors");

                entity.HasIndex(e => e.Value, "UQ__Favorite__07D9BBC2B145BF78")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FavoriteNumber>(entity =>
            {
                entity.ToTable("Favorite_Numbers");

                entity.HasIndex(e => e.Value, "UQ__Favorite__07D9BBC2B0DF47EB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
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
