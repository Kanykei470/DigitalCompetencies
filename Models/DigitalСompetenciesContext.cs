using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DigitalСompetencies1.Models;

public partial class DigitalСompetenciesContext : DbContext
{
    public DigitalСompetenciesContext()
    {
    }

    public DigitalСompetenciesContext(DbContextOptions<DigitalСompetenciesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<TestBank> TestBanks { get; set; }

    public virtual DbSet<TestCategory> TestCategories { get; set; }

    public virtual DbSet<TextsBank> TextsBanks { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DROPSOFJUPITER;Database=DigitalСompetencies;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdWorker).HasColumnName("idWorker");
            entity.Property(e => e.Result1).HasColumnName("result");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.IdWorkerNavigation).WithMany(p => p.Results)
                .HasForeignKey(d => d.IdWorker)
                .HasConstraintName("FK_Results_Worker");
        });

        modelBuilder.Entity<TestBank>(entity =>
        {
            entity.ToTable("TestBank");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.CorrectAns)
                .IsUnicode(false)
                .HasColumnName("correctAns");
            entity.Property(e => e.Op1)
                .IsUnicode(false)
                .HasColumnName("op1");
            entity.Property(e => e.Op2)
                .IsUnicode(false)
                .HasColumnName("op2");
            entity.Property(e => e.Op3)
                .IsUnicode(false)
                .HasColumnName("op3");
            entity.Property(e => e.Op4)
                .IsUnicode(false)
                .HasColumnName("op4");
            entity.Property(e => e.Question)
                .IsUnicode(false)
                .HasColumnName("question");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.TestBanks)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestBank_TestCategory");
        });

        modelBuilder.Entity<TestCategory>(entity =>
        {
            entity.ToTable("TestCategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descriprion)
                .IsUnicode(false)
                .HasColumnName("descriprion");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TextsBank>(entity =>
        {
            entity.ToTable("TextsBank");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ExpectedTime).HasColumnName("expectedTime");
            entity.Property(e => e.Symbols).HasColumnName("symbols");
            entity.Property(e => e.Text)
                .IsUnicode(false)
                .HasColumnName("text");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.ToTable("Worker");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Image)
                .HasColumnType("image")
                .HasColumnName("image");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Position).HasColumnName("position");

            entity.HasOne(d => d.PositionNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.Position)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Worker_Positions");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
