using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class Relation : IRelation
    {
        DataAccess.IRelation _Relation;

        public Relation(DataAccess.IRelation relation)
        {
            this._Relation = relation;
        }

        public DataTable Relation_GetAll()
        {
            return _Relation.Relation_GetAll();
        }
    }
}
