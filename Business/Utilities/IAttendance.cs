using System.Data;
using Model;

namespace Business.Utilities
{
    public interface IAttendance
    {
        int Attendance_Delete(int AttendanceId);
        DataTable Attendance_GetAll(Model.Attendance Attendance);
        int Attendance_Save(Model.Attendance Attendance);
        int Attendance_Out_Save(Model.Attendance Attendance);
    }
}