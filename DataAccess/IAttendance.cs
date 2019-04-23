using System.Data;
using Model;

namespace DataAccess
{
    public interface IAttendance
    {
        int Attendance_Delete(int attendanceId);
        DataTable Attendance_GetAll(Model.Attendance attendance);
        int Attendance_Save(Model.Attendance attendance);
        int Attendance_Out_Save(Model.Attendance attendance);
    }
}