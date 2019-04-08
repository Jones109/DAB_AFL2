using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAB_AFL2.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        
        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        
        //Many to many with course
        public List<Teacher_Courses> Teacher_Courses { get; set; }


        //one to many with groups
        public List<Group> Groups { get; set; }

    }
}
