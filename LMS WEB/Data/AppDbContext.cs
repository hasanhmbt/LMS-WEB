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

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<Month> Months { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    public virtual DbSet<VwAuthor> VwAuthors { get; set; }

    public virtual DbSet<VwBook> VwBooks { get; set; }

    public virtual DbSet<VwBookCategory> VwBookCategories { get; set; }

    public virtual DbSet<VwMostOrderedBook> VwMostOrderedBooks { get; set; }

    public virtual DbSet<VwOperation> VwOperations { get; set; }

    public virtual DbSet<Vworeder> Vworeders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=DB_LibraryWeb; Integrated security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC075E7725E7");
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

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Operatio__3214EC07E639A4AD");

            entity.Property(e => e.AcceptStatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.OperationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Book).WithMany(p => p.Operations).HasConstraintName("FK__Operation__BookI__4F47C5E3");

            entity.HasOne(d => d.Reader).WithMany(p => p.Operations).HasConstraintName("FK__Operation__Reade__503BEA1C");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Oreders__3214EC07DD793EF2");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Readers__3214EC07113456E5");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<VwAuthor>(entity =>
        {
            entity.ToView("VwAuthors");
        });

        modelBuilder.Entity<VwBook>(entity =>
        {
            entity.ToView("VwBooks");

            entity.Property(e => e.ImagePath).IsFixedLength();
        });

        modelBuilder.Entity<VwBookCategory>(entity =>
        {
            entity.ToView("VwBookCategory");
        });

        modelBuilder.Entity<VwMostOrderedBook>(entity =>
        {
            entity.ToView("VwMostOrderedBooks");
        });

        modelBuilder.Entity<VwOperation>(entity =>
        {
            entity.ToView("VwOperations");
        });

        modelBuilder.Entity<Vworeder>(entity =>
        {
            entity.ToView("VWOreders");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
