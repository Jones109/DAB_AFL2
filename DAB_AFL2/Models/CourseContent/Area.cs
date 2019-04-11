using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAB_AFL2.Models.CourseContent
{
    public class Area
    {
        public string ContentUri { get; set; }
       
        public string Name { get; set; }

        [Key]
        public int AreaId { get; set; }


        //Many to one with folder
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
    }
}
