using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB_AFL2.Models.CourseContent
{
    public class Area
    {
        public string contentUri { get; set; }
        [Required]
        public string folder_FK { get; set; }
        [Key]
        public string mainArea { get; set; }
        public string parent { get; set; }
        public Folder Folder { get; set; }
    }
}
