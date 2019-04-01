using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB_AFL2.Models
{
    public class Course
    {
        public string CourseName { get; set; }
        [Key]
        public int CourseId { get; set; }
    }
}
