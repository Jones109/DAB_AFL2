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

        public DbSet<Assignment> Assignments { get; set; }
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
            modelBuilder.Entity<Folder>()
                .HasOne(t => t.Area)
                .WithOne(t => t.Folder)
                .HasForeignKey<Area>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Folders)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.Course_FK);

            modelBuilder.Entity<Folder>()
                .Property(a => a.FolderId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Folder>().HasData(
                new Folder { Course_FK = 1, Name = "Folder1", FolderId = 1 },
                new Folder { Course_FK = 1, Name = "Folder2", FolderId = 2 },
                new Folder { Course_FK = 1, Name = "Folder3", FolderId = 3 },
                new Folder { Course_FK = 2, Name = "Folder4", FolderId = 4 },
                new Folder { Course_FK = 2, Name = "Folder5", FolderId = 5 },
                new Folder { Course_FK = 2, Name = "Folder6", FolderId = 6 },
                new Folder { Course_FK = 3, Name = "Folder7", FolderId = 7 },
                new Folder { Course_FK = 3, Name = "Folder8", FolderId = 8 },
                new Folder { Course_FK = 3, Name = "Folder9", FolderId = 9 },
                new Folder { Course_FK = 1, Name = "Folder10", FolderId = 10,Parent = 1}
            );

            modelBuilder.Entity<Area>().HasData(
                new Area { ContentUri = "SupBro", MainArea = "THIS IS A MAIN AREA", AreaId = 1, FolderId_FK = 1},
                new Area { ContentUri = "SupHo", Parent = "Sub area to main area", AreaId = 2}
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
                new Teacher { TeacherId = 3, Name = "Teacher3" },
                new Teacher { TeacherId = 4, Name = "Teacher4" },
                new Teacher { TeacherId = 5, Name = "Teacher5" },
                new Teacher { TeacherId = 6, Name = "Teacher6" },
                new Teacher { TeacherId = 7, Name = "Teacher7" },
                new Teacher { TeacherId = 8, Name = "Teacher8" }
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
                new Course { CourseId = 3, CourseName = "Course3" },
                new Course { CourseId = 4, CourseName = "Course4" },
                new Course { CourseId = 5, CourseName = "Course5" },
                new Course { CourseId = 6, CourseName = "Course6" },
                new Course { CourseId = 7, CourseName = "Course7" },
                new Course { CourseId = 8, CourseName = "Course8" },
                new Course { CourseId = 9, CourseName = "Course9" }
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
                new Teacher_Courses { TeacherID = 3, CourseID = 3 },
                new Teacher_Courses { TeacherID = 4, CourseID = 4 },
                new Teacher_Courses { TeacherID = 5, CourseID = 5 },
                new Teacher_Courses { TeacherID = 6, CourseID = 6 },
                new Teacher_Courses { TeacherID = 7, CourseID = 7 },
                new Teacher_Courses { TeacherID = 8, CourseID = 8 },
                new Teacher_Courses { TeacherID = 1, CourseID = 9 },
                new Teacher_Courses { TeacherID = 2, CourseID = 5 },
                new Teacher_Courses { TeacherID = 3, CourseID = 7 },
                new Teacher_Courses { TeacherID = 4, CourseID = 9 }
            );
        }

        private void StudentOnModelCreating(ModelBuilder modelBuilder)
        {
            //Seeds 3 Students in the DB
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentID = 1, Birthday = DateTime.Today, EnrollDate = DateTime.Today,GraduateDate = DateTime.Today, Name = "Student1"},
                new Student { StudentID = 2, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student2" },
                new Student { StudentID = 3, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student3" },
                new Student { StudentID = 4, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student4" },
                new Student { StudentID = 5, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student5" },
                new Student { StudentID = 6, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student6" },
                new Student { StudentID = 7, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student7" },
                new Student { StudentID = 8, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student8" },
                new Student { StudentID = 9, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student9" },
                new Student { StudentID = 10, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student10" },
                new Student { StudentID = 11, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student11" },
                new Student { StudentID = 12, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student12" },
                new Student { StudentID = 13, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student13" },
                new Student { StudentID = 14, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student14" },
                new Student { StudentID = 15, Birthday = DateTime.Today, EnrollDate = DateTime.Today, GraduateDate = DateTime.Today, Name = "Student15" }
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
                new Enrolled { CourseId = 1, Status = "Active", StudentId = 1 },
                new Enrolled { CourseId = 2, Status = "Active", StudentId = 1 },
                new Enrolled { CourseId = 3, Status = "Active", StudentId = 2 },
                new Enrolled { CourseId = 4, Status = "Active", StudentId = 2 },
                new Enrolled { CourseId = 5, Status = "Active", StudentId = 3 },
                new Enrolled { CourseId = 6, Status = "Active", StudentId = 3 },
                new Enrolled { CourseId = 7, Status = "Active", StudentId = 4 },
                new Enrolled { CourseId = 8, Status = "Active", StudentId = 4 },
                new Enrolled { CourseId = 9, Status = "Active", StudentId = 5 },
                new Enrolled { CourseId = 1, Status = "Active", StudentId = 5 },
                new Enrolled { CourseId = 2, Status = "Active", StudentId = 6 },
                new Enrolled { CourseId = 3, Status = "Active", StudentId = 7 },
                new Enrolled { CourseId = 4, Status = "Active", StudentId = 8 },
                new Enrolled { CourseId = 5, Status = "Active", StudentId = 9 },
                new Enrolled { CourseId = 6, Status = "Active", StudentId = 10 },
                new Enrolled { CourseId = 7, Status = "Active", StudentId = 11 },
                new Enrolled { CourseId = 8, Status = "Active", StudentId = 12 },
                new Enrolled { CourseId = 9, Status = "Active", StudentId = 13 },
                new Enrolled { CourseId = 1, Status = "Active", StudentId = 14 },
                new Enrolled { CourseId = 2, Status = "Active", StudentId = 15 },
                new Enrolled { CourseId = 3, Status = "Active", StudentId = 15 }
            );
            
        }

        private void GroupOnModelCreating(ModelBuilder modelBuilder)
        {
            
            //Seeds 3 Group in the DB
            modelBuilder.Entity<Group>().HasData(
                new Group {GroupId = 1,Grade = 0, GroupSize = 4, AssignmentID = 1, TeacherId = 1},
                new Group { GroupId = 2, Grade = 7, GroupSize = 3, AssignmentID = 2, TeacherId = 2},
                new Group { GroupId = 3, Grade = 4, GroupSize = 2 , AssignmentID = 3, TeacherId = 3},
                new Group { GroupId = 4, Grade = 0, GroupSize = 4, AssignmentID = 4, TeacherId = 4 },
                new Group { GroupId = 5, Grade = 7, GroupSize = 3, AssignmentID = 5, TeacherId = 5 },
                new Group { GroupId = 6, Grade = 0, GroupSize = 2, AssignmentID = 6, TeacherId = 6 },
                new Group { GroupId = 7, Grade = 4, GroupSize = 4, AssignmentID = 1, TeacherId = 1 },
                new Group { GroupId = 8, Grade = 0, GroupSize = 3, AssignmentID = 2, TeacherId = 2 },
                new Group { GroupId = 9, Grade = 7, GroupSize = 2, AssignmentID = 3, TeacherId = 3 },
                new Group { GroupId = 10, Grade = 0, GroupSize = 4, AssignmentID = 4, TeacherId = 4 },
                new Group { GroupId = 11, Grade = 4, GroupSize = 3, AssignmentID = 5, TeacherId = 5 },
                new Group { GroupId = 12, Grade = 0, GroupSize = 2, AssignmentID = 6, TeacherId = 6 },
                new Group { GroupId = 13, Grade = 4, GroupSize = 4, AssignmentID = 1, TeacherId = 7 },
                new Group { GroupId = 14, Grade = 0, GroupSize = 3, AssignmentID = 2, TeacherId =  8},
                new Group { GroupId = 15, Grade = 10, GroupSize = 2, AssignmentID = 3, TeacherId = 1 },
                new Group { GroupId = 16, Grade = 0, GroupSize = 4, AssignmentID = 4, TeacherId = 2 },
                new Group { GroupId = 17, Grade = 12, GroupSize = 3, AssignmentID = 5, TeacherId = 3 },
                new Group { GroupId = 18, Grade = 0, GroupSize = 2, AssignmentID = 6, TeacherId = 4 }
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
                new GroupStudents { GroupId = 1, StudentId = 2 },
                new GroupStudents { GroupId = 1, StudentId = 3 },
                new GroupStudents { GroupId = 2, StudentId = 4 },
                new GroupStudents { GroupId = 2, StudentId = 5 },
                new GroupStudents { GroupId = 2, StudentId = 6 },
                new GroupStudents { GroupId = 3, StudentId = 7 },
                new GroupStudents { GroupId = 3, StudentId = 8 },
                new GroupStudents { GroupId = 3, StudentId = 9 },
                new GroupStudents { GroupId = 4, StudentId = 10 },
                new GroupStudents { GroupId = 5, StudentId = 11 },
                new GroupStudents { GroupId = 6, StudentId = 12 },
                new GroupStudents { GroupId = 7, StudentId = 13 },
                new GroupStudents { GroupId = 8, StudentId = 14 },
                new GroupStudents { GroupId = 9, StudentId = 15 },
                new GroupStudents { GroupId = 10, StudentId = 1 },
                new GroupStudents { GroupId = 12, StudentId = 2 },
                new GroupStudents { GroupId = 11, StudentId = 3 }
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
                new Assignment { AssignmentID = 3, CourseID = 3 },
                new Assignment { AssignmentID = 4, CourseID = 4 },
                new Assignment { AssignmentID = 5, CourseID = 5 },
                new Assignment { AssignmentID = 6, CourseID = 6 }
            );

        }

    }

}
