﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB_AFL2.Data;
using DAB_AFL2.Models;
using DAB_AFL2.Models.CourseContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace DAB_AFL2.Repositories
{
    class Repository
    {

        private DbContextOptions<BlackboardDbContext> _options;
        public Repository()
        {
            _options = new DbContextOptionsBuilder<BlackboardDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BlackboardDB;Trusted_Connection=true;MultipleActiveResultSets=true")
                .Options;
        }

        public bool CreateDB()
        {
            using (var context = new BlackboardDbContext(_options))
            {
                if (true && (context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return false;

                    context.Database.EnsureDeleted();
                return context.Database.EnsureCreated();
            }
        }


        public async void Enroll(int courseId, int studentId, string status)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                Enrolled enroll = new Enrolled
                {
                    CourseId = courseId,
                    StudentId = studentId,
                    Status =status
                };

                await context.Enrolled.AddAsync(enroll);
                await context.SaveChangesAsync();

            }

        }


        #region ContentArea

        public async Task<List<Folder>> GetContent(int courseId)
        {
            if (CourseExists(courseId).Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {

                    var folders = await context.Folders.Where(x => x.Course_FK == courseId).Include(x=>x.Areas).ToListAsync();
                    return folders;
                }
            }

            return null;
        }

        #endregion


        #region Group

        public async void GradeGroup(int groupId, int grade)
        {
            if (GroupExists(groupId).Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {
                    var entity = await context.Groups.FirstOrDefaultAsync(
                        x => x.GroupId == groupId);

                    entity.Grade = grade;
                    context.Update(entity);
                    await context.SaveChangesAsync();
                }
            }
            

        }

        #endregion

        #region Courses
        public async Task<List<Course>> GetCourses()
        {
            if (IfAnyCourses().Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {
                    var courses = await context.Courses.ToListAsync();

                    return courses;
                }
            }
            return null;
        }
        public async Task<Course> GetCourseStudentsAndTeachers(int id)
        {
            if (CourseExists(id).Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {

                    var course = await context.Courses.Where(c => c.CourseId == id).Include(c => c.Teacher_Courses).ThenInclude(t => t.Teacher)
                        .Include(c => c.Enrolled).ThenInclude(e => e.Student).FirstAsync();

                    return course;
                }

            }

            return null;


        }

       

        public async Task<List<Course>> GetCourses(int studentId)
        {
            if (IfAnyCourses().Result && StudentExists(studentId).Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {
                    var courses = await context.Courses.Where(e => e.Enrolled.Any(s => s.StudentId == studentId)).Include(e=>e.Enrolled).ToListAsync();

                    return courses;
                }
            }
            return null;
        }



        public async Task<List<Folder>> GetFolders(int folderId)
        {
            if (IfAnyFolders().Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {
                    var folders = await context.Folders.Where(f => f.FolderId == folderId).ToListAsync();

                    return folders;
                }
            }

            return null;
        }

        public void InsertCourse(string CourseName)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                Course course = new Course();
                course.CourseName = CourseName;

                context.Courses.Add(course);
                context.SaveChanges();
            }
        }

        #endregion

        


        #region Students
        public async Task<List<Student>> GetStudents()
        {
            if (IfAnyStudents().Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {
                    var students = await context.Students.ToListAsync();

                    return students;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets all the assignments for a student in a course
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="courseID"></param>
        public async Task<List<Group>> GetAssignments(int studentID, int courseID)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                //All the groups that the student is in
                var groups = await context.Groups.Where(gs => gs.GroupStudents.Any(s => s.StudentId == studentID))
                    .Include(g => g.Teacher)
                    .Include(g =>g.Assignment).ThenInclude(c=>c.Course).ToListAsync();

                return groups;

            }
        }
        

        public void InsertStudent(string name, DateTime birthdate)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                Student student = new Student();
                student.Name = name;
                student.Birthday = birthdate;
                student.EnrollDate = DateTime.Now;
                student.GraduateDate = DateTime.Now.AddYears(3);

                context.Students.Add(student);
                context.SaveChanges();
            }
        }
        #endregion

        #region CalenderEvents
        public async Task<Calendar> GetCalendar()
        {
            if (IfAnyCalendar().Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {
                    var calendar = await context.Calendars.Include(c => c.Events).FirstAsync();
                    
                    return calendar;
                }
            }
            return null;
        }

        public void InsertEventToCalendar(string Description,DateTime start,DateTime end)
        {
            if (IfAnyCalendar().Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {
                    var calendar =  context.Calendars.First();
                    if(calendar.Events == null)
                    {
                        calendar.Events = new List<Event>();
                    }
                    Event even = new Event();
                    even.CalendarId = calendar.CalendarId;
                    even.Calendar = calendar;
                    even.Description = Description;
                    even.EndTime = end;
                    even.StartTime = start;

                    calendar.Events.Add(even);

                    context.Events.Add(even);
                    context.SaveChanges();
                }
            }

        }
        #endregion


        #region Assignment

        public async void AddAssignment(string description)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                Assignment newAssignment = new Assignment
                {

                    CourseID = 1,
                    Description = description

                };


                await context.Assignments.AddAsync(newAssignment);
                await context.SaveChangesAsync();
            }


        }

        #endregion

       
        private async Task<bool> IfAnyCourses()
        {
            using (var context = new BlackboardDbContext(_options))
            {
                bool result = await context.Courses.AnyAsync();
                return result;
            }
        }

        private async Task<bool> IfAnyStudents()
        {
            using (var context = new BlackboardDbContext(_options))
            {
                bool result = await context.Students.AnyAsync();
                return result;
            }
        }

        private async Task<bool> IfAnyCalendar()
        {
            using (var context = new BlackboardDbContext(_options))
            {
                bool result = await context.Calendars.AnyAsync();
                return result;
            }
        }


        private async Task<bool> GroupExists(int id)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                if (await context.Groups
                    .AnyAsync(h => h.GroupId == id))
                    return true;
                return false;
            }
        }

        private async Task<bool> StudentExists(int id)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                if (await context.Students
                    .AnyAsync(h => h.StudentID == id))
                    return true;
                return false;
            }
        }


        private async Task<bool> CourseExists(int id)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                if (await context.Courses
                    .AnyAsync(h => h.CourseId == id))
                    return true;
                return false;
            }
        }
        private async Task<bool> IfAnyFolders()
         {
             using (var context = new BlackboardDbContext(_options))
             {
                 bool result = await context.Folders.AnyAsync();
                 return result;
             }
         }

    }
}
