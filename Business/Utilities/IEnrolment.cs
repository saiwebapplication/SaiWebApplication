using System.Data;
using Model;

namespace Business.Utilities
{
    public interface IEnrolment
    {
        int Enrolment_Delete(int enrolmentId);
        DataTable Enrolment_GetAll(Model.Enrolment enrolment);
        int Enrolment_Save(Model.Enrolment enrolment);
    }
}