using System;
using System.Collections.Generic;
using System.Text;

namespace DAB_AFL2.Models
{
    public class Student
    {
        public DateTime EnrollDate { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime GraduateDate { get; set; }
    }
}
