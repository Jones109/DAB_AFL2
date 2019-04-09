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
                    //dc.Students.Where(s => s.StudentCourseEnrollments.Any(e => e.Course.CourseID == courseID)
                    var courses = await context.Courses.Where(e => e.Enrolled.Any(s => s.StudentId == studentId)).ToListAsync();

                    return courses;
                }
            }
            return null;
        }

        #endregion

        public async Task<List<Teacher>> GetTeachers(int courseId)
        {
            using (var context = new BlackboardDbContext(_options))
            {
                
                
            
            }
            
            return null;
        }



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




    }
}
