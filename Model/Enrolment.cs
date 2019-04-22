using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Enrolment
    {
        public Enrolment()
        {

        }

        public int EnrolmentId { get; set; }
        public string EnrolmentNo { get; set; }
        public int BatchId { get; set; }
        public int StudentId { get; set; }
        public DateTime StartDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime StartFromDate { get; set; }
        public DateTime StartToDate { get; set; }
    }
}
