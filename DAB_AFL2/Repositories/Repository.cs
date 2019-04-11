using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB_AFL2.Data;
using DAB_AFL2.Models;
using Microsoft.EntityFrameworkCore;
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


       

        public async Task<List<Course>> GetCourses(int studentId)
        {
            if (IfAnyCourses().Result)
            {
                using (var context = new BlackboardDbContext(_options))
                {
                    var courses = await context.Courses.Where(e => e.Enrolled.Any(s => s.StudentId == studentId)).ToListAsync();

                    return courses;
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

        /*
        public async void GetAssignments(int studentID, int courseID)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                //var assignments = await context.Assignments
                    //Courses.Where(e => e.Enrolled.Where()).ToListAsync();



                //return courses;
            }
        }
        */

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
                    even.StarTime = start;

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

        
    }
}
