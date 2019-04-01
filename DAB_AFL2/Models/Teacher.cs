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
        public int StudentId { get; set; }
        [MaxLength(Int16.MaxValue)]
        public short Birthday { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        

    }
}
