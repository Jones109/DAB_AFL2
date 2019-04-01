using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB_AFL2.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [MaxLength(128)]
        public string CourseName { get; set; }

        //Many-to-many
        public List<Teacher_Courses> Teacher_Courses { get; set; }
    }
}
