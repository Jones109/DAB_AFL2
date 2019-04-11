using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DAB_AFL2.Models.CourseContent
{
    public class Folder
    {
        [Key]
        public int FolderId { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
        public Folder ParentFolder { get; set; }


        //one to many with Area
        public List<Area> Areas { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int Course_FK { get; set; }

        public Course Course { get; set; }
    }
}
