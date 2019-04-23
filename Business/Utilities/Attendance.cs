using System.Data;

namespace Business.Utilities
{
    public class Attendance : IAttendance
    {
        DataAccess.IAttendance _Attendance;

        public Attendance(DataAccess.IAttendance Attendance)
        {
            this._Attendance = Attendance;
        }

        public int Attendance_Save(Model.Attendance Attendance)
        {
            return _Attendance.Attendance_Save(Attendance);

        }

        public DataTable Attendance_GetAll(Model.Attendance Attendance)
        {
            return _Attendance.Attendance_GetAll(Attendance);
        }

        public int Attendance_Delete(int AttendanceId)
        {
            return _Attendance.Attendance_Delete(AttendanceId);
        }

        public int Attendance_Out_Save(Model.Attendance Attendance)
        {
            return _Attendance.Attendance_Out_Save(Attendance);

        }
    }
}
