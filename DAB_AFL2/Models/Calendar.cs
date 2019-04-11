using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace DAB_AFL2.Models
{
    public class Calendar
    {
        [Key]
        public int CalendarId { get; set; }

       public string CalendarName { get; set; }
        public List<Event> Events { get; set; }
    }
}
