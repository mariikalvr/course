using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace projects.Domain.Entities
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Attendances> Attendances { get; set; }
        public DbSet<StudentsInGroups> StudentsInGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()

                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);


            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Course>()
                .HasOne(c => c.CreatedBy)
                .WithMany()
                .HasForeignKey(c => c.CreatedById);

            modelBuilder.Entity<Group>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Group>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.Course)
                .WithMany()
                .HasForeignKey(g => g.CourseId);

            modelBuilder.Entity<StudentsInGroups>()
                .HasKey(sg => sg.Id);

            modelBuilder.Entity<StudentsInGroups>()
                .HasOne(sg => sg.Student)
                .WithMany()
                .HasForeignKey(sg => sg.StudentId);

            modelBuilder.Entity<StudentsInGroups>()
                .HasOne(sg => sg.Group)
                .WithMany()
                .HasForeignKey(sg => sg.GroupId);

            modelBuilder.Entity<Lesson>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Lesson>()
                .Property(l => l.Date)
                .IsRequired();

            modelBuilder.Entity<Lesson>()
                .Property(l => l.Topic)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Group)
                .WithMany()
                .HasForeignKey(l => l.GroupId);

            modelBuilder.Entity<Attendances>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Attendances>()
                .HasOne(a => a.Lesson)
                .WithMany()
                .HasForeignKey(a => a.LessonId);

            modelBuilder.Entity<Attendances>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId);
        }
    }
}

