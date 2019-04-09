using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MemberRelationMapping
    {
        public MemberRelationMapping()
        {

        }

        public int MemberRelationMappingId { get; set; }
        public int FirstMemberId { get; set; }
        public int SecondMemberId { get; set; }
        public int RelationId { get; set; }
    }
}
