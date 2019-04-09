using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MemberActivity
    {
        public MemberActivity()
        {

        }
        public int MemberActivityId { get; set; }
        public int MemberId { get; set; }
        public int ActivityId { get; set; }
        public string Location { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool LikeActivity { get; set; }
        public int CreatedBy { get; set; }
    }
}
