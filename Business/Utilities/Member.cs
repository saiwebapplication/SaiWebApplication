using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class Member : IMember
    {
        DataAccess.IMember _Member;

        public Member(DataAccess.IMember member)
        {
            this._Member = member;
        }

        public int ActivityMaster_Save(Model.Member member)
        {
            return _Member.Member_Save(member);

        }

        public DataTable Member_GetAll(Model.Member member)
        {
            return _Member.Member_GetAll(member);
        }

        public int Member_Delete(int memberId)
        {
            return _Member.Member_Delete(memberId);
        }
    }
}
