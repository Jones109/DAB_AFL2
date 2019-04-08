using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB_AFL2.Models
{
    public class GroupStudents
    {
        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required]
        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
