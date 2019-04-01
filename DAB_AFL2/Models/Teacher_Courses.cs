using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_AFL2.Models
{
    public class Teacher_Courses
    {
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
