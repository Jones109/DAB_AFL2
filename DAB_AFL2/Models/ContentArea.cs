using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB_AFL2.Models
{
    public class ContentArea
    {
        [Key]
        public int AreaId { get; set; }
        public string TextBlock { get; set; }
        public string ContentUri { get; set; }
    }
}
