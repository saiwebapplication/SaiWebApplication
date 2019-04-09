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
    public class MemberAddress : IMemberAddress
    {
        public int MemberAddress_Save(Model.MemberAddress memberAddress)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberAddress_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberAddressDetailsId", memberAddress.MemberAddressDetailsId);
                    cmd.Parameters.AddWithValue("@MemberId", memberAddress.MemberId);
                    cmd.Parameters.AddWithValue("@ResidentialAddress", memberAddress.ResidentialAddress);
                    cmd.Parameters.AddWithValue("@LocalityId", memberAddress.LocalityId);
                    cmd.Parameters.AddWithValue("@Emirates", memberAddress.Emirates);
                    cmd.Parameters.AddWithValue("@CreatedBy", memberAddress.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }

        public DataTable MemberAddress_GetAll(Model.MemberAddress memberAddress)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_MemberAddress_GetAll";
                        if (memberAddress.MemberAddressDetailsId == 0)
                            cmd.Parameters.AddWithValue("@MemberAddressDetailsId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberAddressDetailsId", memberAddress.MemberAddressDetailsId);
                        if (memberAddress.MemberId == 0)
                            cmd.Parameters.AddWithValue("@MemberId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberId", memberAddress.MemberId);
                       
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

        public int MemberAddress_Delete(int memberAddressId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_MemberAddress_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberAddressDetailsId", memberAddressId);
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
