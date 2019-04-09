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
    public class MemberRelationMapping : IMemberRelationMapping
    {
        public int MemberRelationMapping_Save(Model.MemberRelationMapping memberRelationMapping)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberRelationMapping_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberRelationMappingId", memberRelationMapping.MemberRelationMappingId);
                    cmd.Parameters.AddWithValue("@FirstMemberId", memberRelationMapping.FirstMemberId);
                    cmd.Parameters.AddWithValue("@SecondMemberId", memberRelationMapping.SecondMemberId);
                    cmd.Parameters.AddWithValue("@RelationId", memberRelationMapping.RelationId);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }

        public DataTable MemberRelationMapping_GetAll(Model.MemberRelationMapping memberRelationMapping)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_MemberRelationMapping_GetAll";
                        if (memberRelationMapping.MemberRelationMappingId == 0)
                            cmd.Parameters.AddWithValue("@MemberRelationMappingId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberRelationMappingId", memberRelationMapping.MemberRelationMappingId);
                        if (memberRelationMapping.FirstMemberId == 0)
                            cmd.Parameters.AddWithValue("@MemberId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberId", memberRelationMapping.FirstMemberId);

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

        public int MemberRelationMapping_Delete(int memberRelationMappingId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberRelationMapping_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberRelationMappingId", memberRelationMappingId);
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
