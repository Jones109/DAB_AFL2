using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DAB_AFL2.Models.CourseContent
{
    public class Folder
    {
        [Key]
        public string Name { get; set; }

        public string Parent { get; set; }

        public int Course_FK { get; set; }
    }
}
