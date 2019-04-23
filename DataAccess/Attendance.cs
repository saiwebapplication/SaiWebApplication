using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Attendance : IAttendance
    {
        public int Attendance_Save(Model.Attendance attendance)
        {
            int AttendanceId = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Attendance_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttendanceId", attendance.AttendanceId).Direction = ParameterDirection.InputOutput; ;
                    cmd.Parameters.AddWithValue("@AttendanceTypeId", attendance.AttendanceTypeId);
                    cmd.Parameters.AddWithValue("@EventId", attendance.EventId);
                    cmd.Parameters.AddWithValue("@MemberId", attendance.MemberId);
                    cmd.Parameters.AddWithValue("@InDateTime", attendance.InDateTime);
                    cmd.Parameters.AddWithValue("@CreatedBy", attendance.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    AttendanceId = Convert.ToInt32(cmd.Parameters["@AttendanceId"].Value);
                    con.Close();
                }
            }
            return AttendanceId;
        }

        public DataTable Attendance_GetAll(Model.Attendance attendance)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_Attendance_GetAll";
                        if (attendance.AttendanceId == 0)
                            cmd.Parameters.AddWithValue("@AttendanceId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@AttendanceId", attendance.AttendanceId);
                        if (attendance.AttendanceTypeId == 0)
                            cmd.Parameters.AddWithValue("@AttendanceTypeId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@AttendanceTypeId", attendance.AttendanceTypeId);
                        if (attendance.EventId == 0)
                            cmd.Parameters.AddWithValue("@EventId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@EventId", attendance.EventId);
                        if (attendance.MemberId == 0)
                            cmd.Parameters.AddWithValue("@MemberId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberId", attendance.MemberId);
                        if (attendance.FromDateTime == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@FromDateTime", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@FromDateTime", attendance.FromDateTime);
                        if (attendance.ToDateTime == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@ToDateTime", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@ToDateTime", attendance.ToDateTime);
                        if (string.IsNullOrEmpty(attendance.EnrolmentNo))
                            cmd.Parameters.AddWithValue("@EnrolmentNo", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@EnrolmentNo", attendance.EnrolmentNo);
                        if (attendance.AttendanceDate == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@AttendanceDate", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@AttendanceDate", attendance.AttendanceDate);
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                }
                return dt;
            }
        }

        public int Attendance_Delete(int attendanceId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Attendance_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }

        public int Attendance_Out_Save(Model.Attendance attendance)
        {
            int AttendanceId = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Attendance_Out_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttendanceId", attendance.AttendanceId).Direction = ParameterDirection.InputOutput;
                    cmd.Parameters.AddWithValue("@OutDateTime", attendance.OutDateTime);
                    cmd.Parameters.AddWithValue("@CreatedBy", attendance.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    AttendanceId = Convert.ToInt32(cmd.Parameters["@AttendanceId"].Value);
                    con.Close();
                }
            }
            return AttendanceId;
        }
    }
}
