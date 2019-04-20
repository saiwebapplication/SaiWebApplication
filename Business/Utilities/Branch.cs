using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class Branch : IBranch
    {
        DataAccess.IBranch _Branch;
        public DataTable Branch_GetAll()
        {
            return _Branch.Branch_GetAll();
        }
    }
}
