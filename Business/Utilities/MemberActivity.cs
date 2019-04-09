using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class MemberActivity : IMemberActivity
    {
        DataAccess.IMemberActivity _MemberActivity;

        public MemberActivity(DataAccess.IMemberActivity memberActivity)
        {
            this._MemberActivity = memberActivity;
        }

        public int MemberActivity_Save(Model.MemberActivity memberActivity)
        {
            return _MemberActivity.MemberActivity_Save(memberActivity);

        }

        public DataTable MemberActivity_GetAll(Model.MemberActivity memberActivity)
        {
            return _MemberActivity.MemberActivity_GetAll(memberActivity);
        }

        public int MemberActivity_Delete(int memberActivityId)
        {
            return _MemberActivity.MemberActivity_Delete(memberActivityId);
        }
    }
}
