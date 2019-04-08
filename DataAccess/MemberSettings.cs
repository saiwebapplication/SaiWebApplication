using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class MemberSettings : IMemberSettings
    {
        public int MemberSettings_Save(Model.MemberSettings memberSettings)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberSettings_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberSettings.MemberId);
                    cmd.Parameters.AddWithValue("@IsActive", memberSettings.IsActive);
                    cmd.Parameters.AddWithValue("@UserName", memberSettings.UserName);
                    cmd.Parameters.AddWithValue("@Password", memberSettings.Password);
                    cmd.Parameters.AddWithValue("@IsAppLoginEnabled", memberSettings.IsAppLoginEnabled);
                    cmd.Parameters.AddWithValue("@CreatedBy", memberSettings.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }

        public DataTable MemberSettings_GetById(Model.MemberSettings memberSettings)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_MemberSettings_GetById";
                        cmd.Parameters.AddWithValue("@MemberId", memberSettings.MemberId);
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
    }
}
