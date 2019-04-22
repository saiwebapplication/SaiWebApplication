using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class Enrolment : IEnrolment
    {
        DataAccess.IEnrolment _Enrolment;

        public Enrolment(DataAccess.IEnrolment enrolment)
        {
            this._Enrolment = enrolment;
        }

        public int Enrolment_Save(Model.Enrolment enrolment)
        {
            return _Enrolment.Enrolment_Save(enrolment);

        }

        public DataTable Enrolment_GetAll(Model.Enrolment enrolment)
        {
            return _Enrolment.Enrolment_GetAll(enrolment);
        }

        public int Enrolment_Delete(int enrolmentId)
        {
            return _Enrolment.Enrolment_Delete(enrolmentId);
        }
    }
}
