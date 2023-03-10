// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Services;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20221223073935_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentDTOSubjectDTO", b =>
                {
                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("StudentDTOSubjectDTO");

                    b.HasData(
                        new
                        {
                            StudentsId = new Guid("7841bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                            SubjectsId = new Guid("7541c1bc-cb1a-4db6-aaf7-bbed27c2ed49")
                        },
                        new
                        {
                            StudentsId = new Guid("7841bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                            SubjectsId = new Guid("3441bc1b-cb1a-4db6-aaf7-bbed27c2ed49")
                        });
                });

            modelBuilder.Entity("backend.DTOs.InstructorDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                            Name = "John Instructor"
                        });
                });

            modelBuilder.Entity("backend.DTOs.StudentDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Course")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7841bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                            Course = "BSIT",
                            Name = "Jane Student",
                            Year = 4
                        });
                });

            modelBuilder.Entity("backend.DTOs.SubjectDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7541c1bc-cb1a-4db6-aaf7-bbed27c2ed49"),
                            InstructorId = new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                            Name = "Intro to Computing"
                        },
                        new
                        {
                            Id = new Guid("3441bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                            InstructorId = new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                            Name = "Platform Technologies"
                        },
                        new
                        {
                            Id = new Guid("5641bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                            InstructorId = new Guid("2294bc1b-cb1a-4db6-aaf7-bbed27c2ed49"),
                            Name = "Capstone 1"
                        });
                });

            modelBuilder.Entity("StudentDTOSubjectDTO", b =>
                {
                    b.HasOne("backend.DTOs.StudentDTO", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.DTOs.SubjectDTO", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.DTOs.SubjectDTO", b =>
                {
                    b.HasOne("backend.DTOs.InstructorDTO", "Instructor")
                        .WithMany("Subjects")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("backend.DTOs.InstructorDTO", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
