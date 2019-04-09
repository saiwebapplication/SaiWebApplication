﻿using System.Data;
using Model;

namespace Business.Utilities
{
    public interface IMemberRelationMapping
    {
        int MemberRelationMapping_Delete(int memberRelationMappingId);
        DataTable MemberRelationMapping_GetAll(Model.MemberRelationMapping memberRelationMapping);
        int MemberRelationMapping_Save(Model.MemberRelationMapping memberRelationMapping);
    }
}