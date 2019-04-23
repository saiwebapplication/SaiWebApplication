using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Attendance
    {
        public Attendance()
        {

        }

        public int AttendanceId { get; set; }
        public int AttendanceTypeId { get; set; }
        public int EventId { get; set; }
        public int MemberId { get; set; }
        public DateTime InDateTime { get; set; }
        public DateTime OutDateTime { get; set; }
        public int CreatedBy { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public string EnrolmentNo { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
