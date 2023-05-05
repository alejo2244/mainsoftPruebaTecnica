using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Models
{
    public partial class travel_inventory_dbContext : DbContext
    {
        public travel_inventory_dbContext()
        {
        }

        public travel_inventory_dbContext(DbContextOptions<travel_inventory_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorsHaveBook> AuthorsHaveBooks { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ALEJOPC\\SQLEXPRESS; Database=travel_inventory_db; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LastNames)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("last_names");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AuthorsHaveBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("authors_have_books");

                entity.Property(e => e.AuthorsId).HasColumnName("authors_id");

                entity.Property(e => e.BooksIsbn).HasColumnName("books_isbn");

                entity.HasOne(d => d.Authors)
                    .WithMany()
                    .HasForeignKey(d => d.AuthorsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_authors");

                entity.HasOne(d => d.BooksIsbnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.BooksIsbn)
                    .HasConstraintName("fk_books");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__books__99F9D0A5201BEDEF");

                entity.ToTable("books");

                entity.Property(e => e.Isbn)
                    .ValueGeneratedNever()
                    .HasColumnName("isbn");

                entity.Property(e => e.EditorialId).HasColumnName("editorial_id");

                entity.Property(e => e.NPages)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("n_pages");

                entity.Property(e => e.Synopsis)
                    .HasColumnType("text")
                    .HasColumnName("synopsis");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Editorial)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.EditorialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_editorials");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.ToTable("editorials");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Branch)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("branch");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
