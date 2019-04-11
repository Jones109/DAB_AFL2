using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB_AFL2.Models.CourseContent
{
    public class Area
    {
        public string ContentUri { get; set; }
       
        public string MainArea { get; set; }

        [Key]
        public int AreaId { get; set; }

        public string Parent { get; set; }

        public Folder Folder { get; set; }

        public int FolderId_FK { get; set; }
    }
}
