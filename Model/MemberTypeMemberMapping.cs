using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MemberTypeMemberMapping
    {
        public MemberTypeMemberMapping()
        {

        }

        public int MemberTypeMemberMappingId { get; set; }
        public int MemberId { get; set; }
        public int MemberTypeId { get; set; }
        public int CreatedBy { get; set; }
    }
}
