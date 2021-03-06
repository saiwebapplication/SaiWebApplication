﻿using System.Data;
using Model;

namespace Business.Utilities
{
    public interface IMemberActivity
    {
        int MemberActivity_Delete(int memberActivityId);
        DataTable MemberActivity_GetAll(Model.MemberActivity memberActivity);
        int MemberActivity_Save(Model.MemberActivity memberActivity);
    }
}