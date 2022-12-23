using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class SchoolDbContext : DbContext
    {
        private InstructorDTO instructor;
        private List<SubjectDTO> subjects;
        private StudentDTO student;
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
            instructor = new InstructorDTO
            {
                Id = new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                Name = "John Instructor"
            };
            subjects = new List<SubjectDTO>{
              new SubjectDTO{
                Id=new Guid("7541c1bc-cb1a-4db6-aaf7-bbed27c2ed49"),
                Name="Intro to Computing",
                InstructorId=new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49")
              },
              new SubjectDTO{
                Id=new Guid("3441bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                Name="Platform Technologies",
                InstructorId=new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49")
              },
              new SubjectDTO{
                Id=new Guid("5641bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                Name="Capstone 1",
                InstructorId=new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49")
              },
            };
            student = new StudentDTO
            {
                Id = new Guid("7841bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                Name = "Jane Student",
                Course = "BSIT",
                Year = 4,
            };
        }

        public DbSet<InstructorDTO> Instructors { get; set; } = default!;
        public DbSet<SubjectDTO> Subjects { get; set; } = default!;
        public DbSet<StudentDTO> Students { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstructorDTO>().HasData(
              instructor
            );
            modelBuilder.Entity<SubjectDTO>().HasData(
              subjects
            );
            modelBuilder.Entity<StudentDTO>().HasData(
              student
            );
            modelBuilder.Entity<StudentDTO>()
            .HasMany(p => p.Subjects)
            .WithMany(p => p.Students)
            .UsingEntity(j => j.HasData(
              new { StudentsId = student.Id, SubjectsId = subjects[0].Id },
              new { StudentsId = student.Id, SubjectsId = subjects[1].Id }
            ));
        }
    }
}