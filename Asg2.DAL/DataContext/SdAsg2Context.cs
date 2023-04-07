using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Asg2.DAL.Models;

namespace Asg2.DAL.DataContext;

public partial class SdAsg2Context : DbContext
{
    public SdAsg2Context()
    {
    }

    public SdAsg2Context(DbContextOptions<SdAsg2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Lab> Labs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Submision> Submisions { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.ToTable("Attendance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LabId).HasColumnName("lab_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Lab).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.LabId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Labs");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Student");
        });

        modelBuilder.Entity<Lab>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AsdDl)
                .HasColumnType("date")
                .HasColumnName("asd_dl");
            entity.Property(e => e.AsgDescription)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("asg_description");
            entity.Property(e => e.AsgName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("asg_name");
            entity.Property(e => e.Curricula)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("curricula");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Subject).WithMany(p => p.Labs)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Labs_Subjects");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Group)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("group");
            entity.Property(e => e.Hobby)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("hobby");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Subject1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("subject");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subjects_Teacher");
        });

        modelBuilder.Entity<Submision>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.LabId).HasColumnName("lab_id");
            entity.Property(e => e.Link)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("link");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Lab).WithMany(p => p.Submisions)
                .HasForeignKey(d => d.LabId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Submisions_Labs");

            entity.HasOne(d => d.Student).WithMany(p => p.Submisions)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Submisions_Student");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Token1)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("token");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
