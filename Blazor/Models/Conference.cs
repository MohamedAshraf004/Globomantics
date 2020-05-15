using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Models
{
    public class Conference
    {
        public Conference()
        {
            StartDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Location { get; set; }
        [DisplayName("Attendee total")]
        public int AttendeeTotal { get; set; }
    }
}
