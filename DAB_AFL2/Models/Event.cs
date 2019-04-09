using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAB_AFL2.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required] 
        public DateTime StarTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string Description { get; set; }

        public Calendar Calendar { get; set; }
        public int CalendarId { get; set; }
    }
}
