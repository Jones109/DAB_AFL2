﻿// <auto-generated />
using System;
using DAB_AFL2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAB_AFL2.Migrations
{
    [DbContext(typeof(BlackboardDbContext))]
    partial class BlackboardDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAB_AFL2.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attempt");

                    b.Property<int>("CourseID");

                    b.HasKey("AssignmentID");

                    b.HasIndex("CourseID");

                    b.ToTable("Assignment");

                    b.HasData(
                        new
                        {
                            AssignmentID = 1,
                            Attempt = 0,
                            CourseID = 1
                        },
                        new
                        {
                            AssignmentID = 2,
                            Attempt = 0,
                            CourseID = 2
                        },
                        new
                        {
                            AssignmentID = 3,
                            Attempt = 0,
                            CourseID = 3
                        });
                });

            modelBuilder.Entity("DAB_AFL2.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .HasMaxLength(128);

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseName = "Course1"
                        },
                        new
                        {
                            CourseId = 2,
                            CourseName = "Course2"
                        },
                        new
                        {
                            CourseId = 3,
                            CourseName = "Course3"
                        });
                });

            modelBuilder.Entity("DAB_AFL2.Models.Enrolled", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.Property<string>("Status");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrolled");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            StudentId = 1,
                            Status = "Active"
                        },
                        new
                        {
                            CourseId = 2,
                            StudentId = 2,
                            Status = "Active"
                        },
                        new
                        {
                            CourseId = 3,
                            StudentId = 3,
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("DAB_AFL2.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentID");

                    b.Property<int>("Grade");

                    b.Property<int>("GroupSize");

                    b.Property<int>("TeacherId");

                    b.HasKey("GroupId");

                    b.HasIndex("AssignmentID");

                    b.HasIndex("TeacherId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            AssignmentID = 1,
                            Grade = 0,
                            GroupSize = 4,
                            TeacherId = 1
                        },
                        new
                        {
                            GroupId = 2,
                            AssignmentID = 2,
                            Grade = 0,
                            GroupSize = 3,
                            TeacherId = 2
                        },
                        new
                        {
                            GroupId = 3,
                            AssignmentID = 3,
                            Grade = 0,
                            GroupSize = 2,
                            TeacherId = 3
                        });
                });

            modelBuilder.Entity("DAB_AFL2.Models.GroupStudents", b =>
                {
                    b.Property<int>("GroupId");

                    b.Property<int>("StudentId");

                    b.HasKey("GroupId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("GroupStudents");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            StudentId = 1
                        },
                        new
                        {
                            GroupId = 2,
                            StudentId = 2
                        },
                        new
                        {
                            GroupId = 3,
                            StudentId = 3
                        });
                });

            modelBuilder.Entity("DAB_AFL2.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("EnrollDate");

                    b.Property<DateTime>("GraduateDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("StudentID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = 1,
                            Birthday = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EnrollDate = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            GraduateDate = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Student1"
                        },
                        new
                        {
                            StudentID = 2,
                            Birthday = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EnrollDate = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            GraduateDate = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Student2"
                        },
                        new
                        {
                            StudentID = 3,
                            Birthday = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            EnrollDate = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            GraduateDate = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Student3"
                        });
                });

            modelBuilder.Entity("DAB_AFL2.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Teacher1"
                        },
                        new
                        {
                            TeacherId = 2,
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Teacher2"
                        },
                        new
                        {
                            TeacherId = 3,
                            Birthday = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Teacher3"
                        });
                });

            modelBuilder.Entity("DAB_AFL2.Models.Teacher_Courses", b =>
                {
                    b.Property<int>("TeacherID");

                    b.Property<int>("CourseID");

                    b.HasKey("TeacherID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("TeacherCourses");

                    b.HasData(
                        new
                        {
                            TeacherID = 1,
                            CourseID = 1
                        },
                        new
                        {
                            TeacherID = 2,
                            CourseID = 2
                        },
                        new
                        {
                            TeacherID = 3,
                            CourseID = 3
                        });
                });

            modelBuilder.Entity("DAB_AFL2.Models.Assignment", b =>
                {
                    b.HasOne("DAB_AFL2.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAB_AFL2.Models.Enrolled", b =>
                {
                    b.HasOne("DAB_AFL2.Models.Course", "Course")
                        .WithMany("Enrolled")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAB_AFL2.Models.Student", "Student")
                        .WithMany("Enrolled")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAB_AFL2.Models.Group", b =>
                {
                    b.HasOne("DAB_AFL2.Models.Assignment", "Assignment")
                        .WithMany("Groups")
                        .HasForeignKey("AssignmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAB_AFL2.Models.Teacher", "Teacher")
                        .WithMany("Groups")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAB_AFL2.Models.GroupStudents", b =>
                {
                    b.HasOne("DAB_AFL2.Models.Group", "Group")
                        .WithMany("GroupStudents")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAB_AFL2.Models.Student", "Student")
                        .WithMany("GroupStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAB_AFL2.Models.Teacher_Courses", b =>
                {
                    b.HasOne("DAB_AFL2.Models.Course", "Course")
                        .WithMany("Teacher_Courses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAB_AFL2.Models.Teacher", "Teacher")
                        .WithMany("Teacher_Courses")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
