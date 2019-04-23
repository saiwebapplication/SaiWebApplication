using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class MemberTypeMemberMapping : IMemberTypeMemberMapping
    {
        public int MemberTypeMemberMapping_Save(Model.MemberTypeMemberMapping memberTypeMemberMapping)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberTypeMemberMapping_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberTypeMemberMappingId", memberTypeMemberMapping.MemberTypeMemberMappingId);
                    cmd.Parameters.AddWithValue("@MemberId", memberTypeMemberMapping.MemberId);
                    cmd.Parameters.AddWithValue("@MemberTypeId", memberTypeMemberMapping.MemberTypeId);
                    cmd.Parameters.AddWithValue("@CreatedBy", memberTypeMemberMapping.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }

        public DataTable MemberTypeMemberMapping_GetByMemberId(int memberId)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_MemberTypeMemberMapping_GetByMemberId";

                        cmd.Parameters.AddWithValue("@MemberId", memberId);

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

        public int MemberTypeMemberMapping_Delete(int memberTypeMemberMappingId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberTypeMemberMapping_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberTypeMemberMappingId", memberTypeMemberMappingId);
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
