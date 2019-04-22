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
    public class Enrolment : IEnrolment
    {
        public int Enrolment_Save(Model.Enrolment enrolment)
        {
            int EnrolmentId = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Enrolment_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnrollmentId", enrolment.EnrolmentId).Direction = ParameterDirection.InputOutput;
                    cmd.Parameters.AddWithValue("@BatchId", enrolment.BatchId);
                    cmd.Parameters.AddWithValue("@EnrolmentNo", enrolment.EnrolmentNo);
                    cmd.Parameters.AddWithValue("@StudentId", enrolment.StudentId);
                    cmd.Parameters.AddWithValue("@StartDate", enrolment.StartDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", enrolment.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    EnrolmentId = Convert.ToInt32(cmd.Parameters["@EnrollmentId"].Value);
                    con.Close();
                }
            }
            return EnrolmentId;
        }

        public DataTable Enrolment_GetAll(Model.Enrolment enrolment)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_Enrolment_GetAll";
                        if (enrolment.EnrolmentId == 0)
                            cmd.Parameters.AddWithValue("@EnrollmentId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@EnrollmentId", enrolment.EnrolmentId);
                        if (enrolment.BatchId == 0)
                            cmd.Parameters.AddWithValue("@BatchId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@BatchId", enrolment.BatchId);
                        if (enrolment.StudentId == 0)
                            cmd.Parameters.AddWithValue("@StudentId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@StudentId", enrolment.StudentId);
                        if (enrolment.StartFromDate == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@StartFromDate", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@StartFromDate", enrolment.StartFromDate);
                        if (enrolment.StartToDate == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@StartToDate", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@StartToDate", enrolment.StartToDate);
                        if (string.IsNullOrEmpty(enrolment.EnrolmentNo))
                            cmd.Parameters.AddWithValue("@EnrolmentNo", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@EnrolmentNo", enrolment.EnrolmentNo);
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

        public int Enrolment_Delete(int enrolmentId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Enrolment_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnrollmentId", enrolmentId);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }
    }
}
