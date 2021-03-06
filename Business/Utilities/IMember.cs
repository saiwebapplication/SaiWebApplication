﻿using System.Data;
using Model;

namespace Business.Utilities
{
    public interface IMember
    {
        int Member_Save(Model.Member member);
        int Member_Delete(int memberId);
        DataTable Member_GetAll(Model.Member member);
    }
}