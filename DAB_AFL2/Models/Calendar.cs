using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAB_AFL2.Models
{
    public class Calendar
    {
        public int CalendarId { get; set; }
        public List<Event> Events { get; set; }
    }
}
