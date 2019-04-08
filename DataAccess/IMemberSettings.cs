using System.Data;
using Model;

namespace DataAccess
{
    public interface IMemberSettings
    {
        DataTable MemberSettings_GetById(Model.MemberSettings memberSettings);
        int MemberSettings_Save(Model.MemberSettings memberSettings);
    }
}