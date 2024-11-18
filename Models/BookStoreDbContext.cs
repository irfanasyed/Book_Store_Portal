using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Book_Store_Portal.Models;

public partial class BookStoreDbContext : DbContext
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<PubInfo> PubInfos { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Roysched> Royscheds { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<Titleauthor> Titleauthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=IRFANA\\SQLSERVER2022;Initial Catalog=Book_Store_Db;User Id=sa;Password=user123;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuId);

            entity.ToTable("authors");

            entity.Property(e => e.AuId)
                .ValueGeneratedNever()
                .HasColumnName("au_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.AuFname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("au_fname");
            entity.Property(e => e.AuLname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("au_lname");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Contract).HasColumnName("contract");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Zip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("discounts");

            entity.Property(e => e.Discount1)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("discount");
            entity.Property(e => e.Discounttype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("discounttype");
            entity.Property(e => e.Highqty).HasColumnName("highqty");
            entity.Property(e => e.Lowqty).HasColumnName("lowqty");
            entity.Property(e => e.StorId).HasColumnName("stor_id");

            entity.HasOne(d => d.Stor).WithMany()
                .HasForeignKey(d => d.StorId)
                .HasConstraintName("FK_discounts_stores");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("employee");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("emp_id");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasColumnName("hire_date");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.JobLvl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_lvl");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.Minit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("minit");
            entity.Property(e => e.PubId).HasColumnName("pub_id");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_employee_jobs");

            entity.HasOne(d => d.Pub).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PubId)
                .HasConstraintName("FK_employee_publishers");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("jobs");

            entity.Property(e => e.JobId)
                .ValueGeneratedNever()
                .HasColumnName("job_id");
            entity.Property(e => e.JobDesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_desc");
            entity.Property(e => e.MaxLvl)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("max_lvl");
            entity.Property(e => e.MinLvl)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("min_lvl");
        });

        modelBuilder.Entity<PubInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pub_info");

            entity.Property(e => e.Logo)
                .IsUnicode(false)
                .HasColumnName("logo");
            entity.Property(e => e.PrInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pr_info");
            entity.Property(e => e.PubId).HasColumnName("pub_id");

            entity.HasOne(d => d.Pub).WithMany()
                .HasForeignKey(d => d.PubId)
                .HasConstraintName("FK_pub_info_publishers");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PubId);

            entity.ToTable("publishers");

            entity.Property(e => e.PubId)
                .ValueGeneratedNever()
                .HasColumnName("pub_id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.PubName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pub_name");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
        });

        modelBuilder.Entity<Roysched>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("roysched");

            entity.Property(e => e.Hirange)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("hirange");
            entity.Property(e => e.Lorange)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("lorange");
            entity.Property(e => e.Royalty)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("royalty");
            entity.Property(e => e.TitleId).HasColumnName("title_id");

            entity.HasOne(d => d.Title).WithMany()
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("FK_roysched_titles");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sales");

            entity.Property(e => e.OrdDate)
                .HasColumnType("datetime")
                .HasColumnName("ord_date");
            entity.Property(e => e.OrdNum).HasColumnName("ord_num");
            entity.Property(e => e.Payterms)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("payterms");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.StorId).HasColumnName("stor_id");
            entity.Property(e => e.TitleId).HasColumnName("title_id");

            entity.HasOne(d => d.Stor).WithMany()
                .HasForeignKey(d => d.StorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sales_stores");

            entity.HasOne(d => d.Title).WithMany()
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("FK_sales_titles");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StorId);

            entity.ToTable("stores");

            entity.Property(e => e.StorId)
                .ValueGeneratedNever()
                .HasColumnName("stor_id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.StorAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("stor_address");
            entity.Property(e => e.StorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("stor_name");
            entity.Property(e => e.Zip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.ToTable("titles");

            entity.Property(e => e.TitleId)
                .ValueGeneratedNever()
                .HasColumnName("title_id");
            entity.Property(e => e.Advance)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("advance");
            entity.Property(e => e.Notes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.PubId).HasColumnName("pub_id");
            entity.Property(e => e.Pubdate)
                .HasColumnType("datetime")
                .HasColumnName("pubdate");
            entity.Property(e => e.Royalty)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("royalty");
            entity.Property(e => e.Title1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.YtdSales)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ytd_sales");

            entity.HasOne(d => d.Pub).WithMany(p => p.Titles)
                .HasForeignKey(d => d.PubId)
                .HasConstraintName("FK_titles_publishers");
        });

        modelBuilder.Entity<Titleauthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("titleauthor");

            entity.Property(e => e.AuId).HasColumnName("au_id");
            entity.Property(e => e.AuOrd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("au_ord");
            entity.Property(e => e.Royaltyper)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("royaltyper");
            entity.Property(e => e.TitleId).HasColumnName("title_id");

            entity.HasOne(d => d.Au).WithMany()
                .HasForeignKey(d => d.AuId)
                .HasConstraintName("FK_titleauthor_authors");

            entity.HasOne(d => d.Title).WithMany()
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("FK_titleauthor_titles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
