using System.Data;

namespace DataAccess
{
    public interface IRelation
    {
        DataTable Relation_GetAll();
    }
}