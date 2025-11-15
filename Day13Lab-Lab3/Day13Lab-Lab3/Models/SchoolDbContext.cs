using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Day13Lab_Lab3.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Learner> Learners { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D7187AD5DA963");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F6877FBDAFDE006");

            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrollmen__Cours__5070F446");

            entity.HasOne(d => d.Learner).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enrollmen__Learn__5165187F");
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.HasKey(e => e.LearnerId).HasName("PK__Learner__67ABFCFAF2642E8B");

            entity.ToTable("Learner");

            entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
            entity.Property(e => e.FirstMidName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MajorId).HasColumnName("MajorID");

            entity.HasOne(d => d.Major).WithMany(p => p.Learners)
                .HasForeignKey(d => d.MajorId)
                .HasConstraintName("FK__Learner__MajorID__4BAC3F29");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.MajorId).HasName("PK__Major__D5B8BFB1087DC7BB");

            entity.ToTable("Major");

            entity.Property(e => e.MajorId).HasColumnName("MajorID");
            entity.Property(e => e.MajorName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
