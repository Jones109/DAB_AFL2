using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace DAB_AFL2.Models
{
    public class Enrolled
    {
        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string Status { get; set; }
    }
}
