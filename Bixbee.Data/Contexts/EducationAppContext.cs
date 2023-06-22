using System;
using System.Collections.Generic;
using Bixbee.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Bixbee.Data.Contexts;

public partial class EducationAppContext : DbContext
{
    public EducationAppContext()
    {
    }

    public EducationAppContext(DbContextOptions<EducationAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Institution> Institutions { get; set; }

    public virtual DbSet<InstitutionCategory> InstitutionCategories { get; set; }

    public virtual DbSet<InstitutionType> InstitutionTypes { get; set; }

    public virtual DbSet<LGA> LGAs { get; set; }

    public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5GF0C72;database=EducationApp; user id=sa;password=asdf@1234; Trusted_Connection=false; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Institution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_University");

            entity.ToTable("Institution");

            entity.Property(e => e.StateCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.University).IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Institutions)
                .HasForeignKey(d => d.CategoryID)
                .HasConstraintName("FK_Institution_InstitutionCategory");

            entity.HasOne(d => d.Type).WithMany(p => p.Institutions)
                .HasForeignKey(d => d.TypeID)
                .HasConstraintName("FK_Institution_InstitutionType");
        });

        modelBuilder.Entity<InstitutionCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UniversityClass");

            entity.ToTable("InstitutionCategory");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InstitutionType>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_UniversityCategory");

            entity.ToTable("InstitutionType");

            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LGA>(entity =>
        {
            entity.Property(e => e.StateCode).IsUnicode(false);
            entity.Property(e => e.Town).IsUnicode(false);

            entity.HasOne(d => d.State).WithMany(p => p.LGAs)
                .HasForeignKey(d => d.StateID)
                .HasConstraintName("FK_LGAs_States");
        });

        modelBuilder.Entity<RegisteredUser>(entity =>
        {
            entity.Property(e => e.ActivationStatus).HasDefaultValueSql("((0))");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsLocked).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastAccess).HasColumnType("datetime");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.VerificationToken).IsUnicode(false);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.Property(e => e.Capital).IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Latitude).IsUnicode(false);
            entity.Property(e => e.Longtitude).IsUnicode(false);
            entity.Property(e => e.State1)
                .IsUnicode(false)
                .HasColumnName("State");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
