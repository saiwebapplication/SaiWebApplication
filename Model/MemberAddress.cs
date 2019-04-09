using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MemberAddress
    {
        public MemberAddress()
        {

        }

        public int MemberAddressDetailsId { get; set; }
        public int MemberId { get; set; }
        public string ResidentialAddress { get; set; }
        public int LocalityId { get; set; }
        public string Emirates { get; set; }
        public int CreatedBy { get; set; }
    }
}
