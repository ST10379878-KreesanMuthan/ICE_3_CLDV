using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SMS.Models;

namespace SMS.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__ENROLLME__7F6877FB32CD4B00");

            entity.ToTable("ENROLLMENT");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.Status)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Module).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__ENROLLMEN__Modul__3C69FB99");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ENROLLMEN__Stude__3B75D760");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Module__2B747787C75D0616");

            entity.ToTable("Module");

            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.Code)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A799006E53D");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Stnumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STNumber");
            entity.Property(e => e.Surname)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
