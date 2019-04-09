using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MemberJob
    {
        public MemberJob()
        {

        }
        public int MemberJobDetailsId { get; set; }
        public int MemberId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Emirates { get; set; }
        public int CreatedBy { get; set; }

        public static implicit operator MemberJob(MemberAddress v)
        {
            throw new NotImplementedException();
        }
    }
}
