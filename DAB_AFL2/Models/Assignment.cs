using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAB_AFL2.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }

        public int Attempt { get; set; }

        //many to one with Course
        [Required]
        public int CourseID { get; set; }
        public Course Course { get; set; }

        //one to many with group
         public List<Group> Groups { get; set; }

    }
}
