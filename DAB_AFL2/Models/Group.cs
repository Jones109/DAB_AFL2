using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB_AFL2.Models
{
    public class Group
    {
        public int Grade { get; set; }

        [Key]
        public int GroupId { get; set; }
        public int GroupSize { get; set; }


        //many to one with teacher
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }


        //Many to many with students
        public List<GroupStudents> GroupStudents { get; set; }


        //One to many with Assignment
        [Required]
        public int AssignmentID { get; set; }
        public Assignment Assignment { get; set; }


    }
}
