using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class MemberActivity : IMemberActivity
    {
        public int MemberActivity_Save(Model.MemberActivity memberActivity)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberActivity_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberActivityId", memberActivity.MemberActivityId);
                    cmd.Parameters.AddWithValue("@MemberId", memberActivity.MemberId);
                    cmd.Parameters.AddWithValue("@ActivityId", memberActivity.ActivityId);
                    cmd.Parameters.AddWithValue("@Location", memberActivity.Location);
                    if (memberActivity.FromDate == DateTime.MinValue)
                        cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@FromDate", memberActivity.FromDate);
                    if (memberActivity.ToDate == DateTime.MinValue)
                        cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ToDate", memberActivity.ToDate);
                    cmd.Parameters.AddWithValue("@LikeActivity", memberActivity.LikeActivity);
                    cmd.Parameters.AddWithValue("@CreatedBy", memberActivity.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }

        public DataTable MemberActivity_GetAll(Model.MemberActivity memberActivity)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_MemberActivity_GetAll";
                        if (memberActivity.MemberActivityId == 0)
                            cmd.Parameters.AddWithValue("@MemberActivityId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberActivityId", memberActivity.MemberActivityId);
                        if (memberActivity.MemberId == 0)
                            cmd.Parameters.AddWithValue("@MemberId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberId", memberActivity.MemberId);

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

        public int MemberActivity_Delete(int memberActivityId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberActivity_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberActivityId", memberActivityId);
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
