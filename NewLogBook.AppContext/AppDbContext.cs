using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NewLogBook.Entities;

namespace NewLogBook.AppContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Facultie> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubject> TeachersSubjects { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Facultie>().HasMany(z => z.Groups).WithOne();
            builder.Entity<Group>().HasOne(z => z.Facultie)
                .WithMany(x => x.Groups).HasForeignKey(z => z.FacultieId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Student>().HasOne(z => z.Group).WithMany(x => x.Students)
                .HasForeignKey(z => z.GroupId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Department>().HasMany(z => z.Teachers).WithOne();
            builder.Entity<Mark>().HasOne(z => z.Student).WithMany(x => x.Marks)
                .HasForeignKey(z => z.StudentId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Mark>().HasOne(z => z.TeacherSubject).WithMany(x => x.Marks)
                .HasForeignKey(z => z.TeacherSubjectId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Subject>().HasMany(z => z.TeachersSubjects).WithOne();
            builder.Entity<Teacher>().HasOne(z => z.Department).WithMany(x => x.Teachers)
                .HasForeignKey(z => z.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Teacher>().HasMany(z => z.TeacherSubjects).WithOne();
            builder.Entity<TeacherSubject>().HasOne(z => z.Teacher).WithMany(x => x.TeacherSubjects)
                .HasForeignKey(z => z.TeacherId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<TeacherSubject>().HasOne(z => z.Subject).WithMany(x => x.TeachersSubjects)
                .HasForeignKey(z => z.SubjectId).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(builder);
            builder.Entity<Facultie>().HasData(
                new Facultie
                {
                    Id = 1,
                    Name = "Programming",
                },
                new Facultie
                {
                    Id = 2,
                    Name = "System administration and security",
                },
                new Facultie
                {
                    Id = 3,
                    Name = "Disign",

                },
                new Facultie
                {
                    Id = 5,
                    Name = "Base",
                });

            builder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "PP-12-1", FacultieId = 1 },
                new Group { Id = 2, Name = "PP-12-2", FacultieId = 1 },
                new Group { Id = 3, Name = "PP-12-3", FacultieId = 1 },
                new Group { Id = 4, Name = "PP-12-4", FacultieId = 1 });
        }
    }
}
