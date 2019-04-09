using System.Data;

namespace Business.Utilities
{
    public interface IRelation
    {
        DataTable Relation_GetAll();
    }
}