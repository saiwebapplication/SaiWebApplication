using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Event
    {
        public Event()
        {

        }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int EventTypeId { get; set; }
        public string Description { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public int BranchId { get; set; }
        public string Venue { get; set; }
        public int CreatedBy { get; set; }
    }
}
