using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class Occupation : IOccupation
    {
        DataAccess.IOccupation _Occupation;

        public Occupation(DataAccess.IOccupation occupation)
        {
            this._Occupation = occupation;
        }

        public DataTable Occupation_GetAll()
        {
            return _Occupation.Occupation_GetAll();
        }
    }
}
