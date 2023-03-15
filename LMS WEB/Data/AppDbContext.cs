using System;
using System.Collections.Generic;
using LMS_WEB.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorImage> AuthorImages { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<BookImage> BookImages { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    public virtual DbSet<VwBook> VwBooks { get; set; }

    public virtual DbSet<VwOperation> VwOperations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=DB_LibraryWeb; Integrated security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC075E7725E7");
        });

        modelBuilder.Entity<AuthorImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuthorIm__3214EC07CC2F75A0");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Author).WithMany(p => p.AuthorImages).HasConstraintName("FK__AuthorIma__Autho__17F790F9");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC0781DC8F87");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasConstraintName("FK__Books__AuthorId__14270015");

            entity.HasOne(d => d.Category).WithMany(p => p.Books).HasConstraintName("FK__Books__CategoryI__19DFD96B");
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookCate__3214EC07DCAE4D49");

            entity.Property(e => e.CategoryDescription).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<BookImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookImag__3214EC07CAA1CCDC");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Book).WithMany(p => p.BookImages).HasConstraintName("FK__BookImage__BookI__6D0D32F4");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Operatio__3214EC0768B37796");

            entity.Property(e => e.OperationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Book).WithMany(p => p.Operations).HasConstraintName("FK__Operation__BookI__6E01572D");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Readers__3214EC07113456E5");

            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<VwBook>(entity =>
        {
            entity.ToView("VwBooks");
        });

        modelBuilder.Entity<VwOperation>(entity =>
        {
            entity.ToView("VwOperation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
