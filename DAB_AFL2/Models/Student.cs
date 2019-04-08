using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace DAB_AFL2.Models
{
    public class Student
    {
        public DateTime EnrollDate { get; set; }

        [Key]
        public int StudentID { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime GraduateDate { get; set; }

        //Many to many with Course
        public List<Enrolled> Enrolled { get; set; }

        //Many to many with student
        public List<GroupStudents> GroupStudents { get; set; }
    }
}
