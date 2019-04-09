using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAB_AFL2.Models;
using DAB_AFL2.Models.CourseContent;

namespace DAB_AFL2.Data
{
    public class BlackboardDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Teacher_Courses> TeacherCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrolled> Enrolled  { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Event> Events { get; set; }
            
        public DbSet<GroupStudents> GroupStudents { get; set; }

        public Assignment Assignments { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Folder> Folders { get; set; }


        public BlackboardDbContext()
        {
        }

        public BlackboardDbContext(DbContextOptions<BlackboardDbContext> options) : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BlackboardDB;Trusted_Connection=true;MultipleActiveResultSets=true");

            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CourseOnModelCreating(modelBuilder);
            AssignmentOnModelCreating(modelBuilder);
            GroupOnModelCreating(modelBuilder);
            StudentOnModelCreating(modelBuilder);
            TeacherOnModelCreating(modelBuilder);
            EnrolledOnModelCreating(modelBuilder);
            GroupStudentsOnModelCreating(modelBuilder);
            Teacher_CoursesOnModelCreating(modelBuilder);
            CourseContentOnModelCreating(modelBuilder);

        }


        private void CourseContentOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Folders)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.Course_FK);

            modelBuilder.Entity<Folder>()
                .HasOne(t => t.Area)
                .WithOne(t => t.Folder)
                .HasForeignKey<Area>();

            modelBuilder.Entity<Area>()
                .HasOne(t => t.Folder)
                .WithOne(t => t.Area);

            modelBuilder.Entity<Area>().HasData(
                new Area { contentUri = "SupBro",folder_FK = "Folder1", mainArea = "MainDataWithBigFont", },
                new Area { contentUri = "SupHo", folder_FK = "Folder1",  mainArea = "SubDataWithSmallerFont", parent = "MainDataWithBigFont" }
            );

            modelBuilder.Entity<Folder>().HasData(
                new Folder { Course_FK = 1, Name = "Folder1" },
                new Folder { Course_FK = 1, Name = "Folder2" },
                new Folder { Course_FK = 1, Name = "Folder3" },
                new Folder { Course_FK = 2, Name = "Folder1" },
                new Folder { Course_FK = 2, Name = "Folder2" },
                new Folder { Course_FK = 2, Name = "Folder3" },
                new Folder { Course_FK = 3, Name = "Folder1" },
                new Folder { Course_FK = 3, Name = "Folder2" },
                new Folder { Course_FK = 3, Name = "Folder3" }
            );
        }


        private void TeacherOnModelCreating(ModelBuilder modelBuilder)
        {
            //Make the one to many relationship to groups
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Groups)
                .WithOne(g => g.Teacher)
                .HasForeignKey(g => g.TeacherId);
            
            //Seeds 3 teachers in the DB
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1,Name ="Teacher1" },
                new Teacher { TeacherId = 2, Name = "Teacher2" },
                new Teacher { TeacherId = 3, Name = "Teacher3" }
            );
        }

        private void CourseOnModelCreating(ModelBuilder modelBuilder)
        {
            //Make the one to many relationship to Assignments
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Assignments)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseID);
            
            //Seeds 3 teachers in the DB
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1,CourseName = "Course1"},
                new Course { CourseId = 2, CourseName = "Course2" },
                new Course { CourseId = 3, CourseName = "Course3" }
            );
        }

        private void Teacher_CoursesOnModelCreating(ModelBuilder modelBuilder)
        {
            //Sets up the primary key for Teacher_courses
            modelBuilder.Entity<Teacher_Courses>().HasKey(eg => new { eg.TeacherID, eg.CourseID });

            //Make the many to many relationship between courses and teachers
            modelBuilder.Entity<Teacher_Courses>()
                .HasOne<Teacher>(sc => sc.Teacher)
                .WithMany(s => s.Teacher_Courses)
                .HasForeignKey(sc => sc.TeacherID);

            modelBuilder.Entity<Teacher_Courses>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.Teacher_Courses)
                .HasForeignKey(sc => sc.CourseID);
            
            //Seeds 3 Teacher_courses in the DB
            modelBuilder.Entity<Teacher_Courses>().HasData(
                new Teacher_Courses { TeacherID = 1, CourseID = 1},
                new Teacher_Courses { TeacherID = 2, CourseID = 2 },
                new Teacher_Courses { TeacherID = 3, CourseID = 3 }
            );
        }

        private void StudentOnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeds 3 Students in the DB
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentID = 1, Birthday = DateTime.Today,EnrollDate = DateTime.Today,GraduateDate = DateTime.Today, Name = "Student1"},
                new Student { StudentID = 2, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student2" },
                new Student { StudentID = 3, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student3" }
            );
        }

        private void EnrolledOnModelCreating(ModelBuilder modelBuilder)
        {
            //Sets up the primary key for Enrolled
            modelBuilder.Entity<Enrolled>().HasKey(eg => new { eg.CourseId, eg.StudentId });

            //Make the many to many relationship between courses and Students
            modelBuilder.Entity<Enrolled>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.Enrolled)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<Enrolled>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.Enrolled)
                .HasForeignKey(sc => sc.CourseId);
            
            //Seeds 3 enrolled in the DB
            modelBuilder.Entity<Enrolled>().HasData(
                new Enrolled { CourseId = 1,Status = "Active", StudentId = 1 },
                new Enrolled { CourseId = 2, Status = "Active", StudentId = 2 },
                new Enrolled { CourseId = 3, Status = "Active", StudentId = 3 }
            );
            
        }

        private void GroupOnModelCreating(ModelBuilder modelBuilder)
        {
            
            //Seeds 3 Group in the DB
            modelBuilder.Entity<Group>().HasData(
                new Group {GroupId = 1,Grade = 0, GroupSize = 4, AssignmentID = 1, TeacherId = 1},
                new Group { GroupId = 2, Grade = 0, GroupSize = 3, AssignmentID = 2, TeacherId = 2},
                new Group { GroupId = 3, Grade = 0, GroupSize = 2 , AssignmentID = 3, TeacherId = 3}
            );
            
        }

        private void CalendarOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendar>()
                .HasMany(c => c.Events)
                .WithOne(a => a.Calendar)
                .HasForeignKey(a => a.CalendarId);

            modelBuilder.Entity<Calendar>().HasData(
                new Calendar { CalendarId = 1 }
            );
        }

        private void EventOnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Event>()
                .HasOne(c => c.Calendar)
                .WithMany(a => a.Events)
                .HasForeignKey(a => a.EventId);
        }

        private void GroupStudentsOnModelCreating(ModelBuilder modelBuilder)
        {
            //Sets up the primary key for GroupStudents
            modelBuilder.Entity<GroupStudents>().HasKey(eg => new { eg.GroupId, eg.StudentId });

            //Make the many to many relationship between groups and students
            modelBuilder.Entity<GroupStudents>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.GroupStudents)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<GroupStudents>()
                .HasOne<Group>(sc => sc.Group)
                .WithMany(s => s.GroupStudents)
                .HasForeignKey(sc => sc.GroupId);
            
            //Seeds 3 GroupStudents in the DB
            modelBuilder.Entity<GroupStudents>().HasData(
                new GroupStudents { GroupId = 1, StudentId = 1},
                new GroupStudents { GroupId = 2, StudentId = 2 },
                new GroupStudents { GroupId = 3, StudentId = 3 }
            );
            
        }

        private void AssignmentOnModelCreating(ModelBuilder modelBuilder)
        {
            //Make the one to many relationship to Groups
            modelBuilder.Entity<Assignment>()
                .HasMany(a => a.Groups)
                .WithOne(g => g.Assignment)
                .HasForeignKey(g => g.AssignmentID);
            
            //Seeds 3 Assignments in the DB
            modelBuilder.Entity<Assignment>().HasData(
                new Assignment { AssignmentID = 1, CourseID = 1},
                new Assignment { AssignmentID = 2, CourseID = 2 },
                new Assignment { AssignmentID = 3, CourseID = 3 }
            );

        }

    }

}
