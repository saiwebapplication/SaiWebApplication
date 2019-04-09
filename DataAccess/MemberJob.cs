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
    public class MemberJob : IMemberJob
    {
        public int MemberJob_Save(Model.MemberJob memberJob)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberJob_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberJobDetailsId", memberJob.MemberJobDetailsId);
                    cmd.Parameters.AddWithValue("@MemberId", memberJob.MemberId);
                    cmd.Parameters.AddWithValue("@CompanyName", memberJob.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyAddress", memberJob.CompanyAddress);
                    cmd.Parameters.AddWithValue("@Emirates", memberJob.Emirates);
                    cmd.Parameters.AddWithValue("@CreatedBy", memberJob.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }

        public DataTable MemberJob_GetAll(Model.MemberJob memberJob)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_MemberJob_GetAll";
                        if (memberJob.MemberJobDetailsId == 0)
                            cmd.Parameters.AddWithValue("@MemberJobDetailsId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberJobDetailsId", memberJob.MemberJobDetailsId);
                        if (memberJob.MemberId == 0)
                            cmd.Parameters.AddWithValue("@MemberId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberId", memberJob.MemberId);

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

        public int MemberJob_Delete(int memberJobId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberJob_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberJobDetailsId", memberJobId);
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
