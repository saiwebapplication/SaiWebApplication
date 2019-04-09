using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Member : IMember
    {
        public int Member_Save(Model.Member member)
        {
            int memberId = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Member_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", member.MemberId).Direction = ParameterDirection.InputOutput; ;
                    cmd.Parameters.AddWithValue("@Salutation", member.Salutation);
                    cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", member.LastName);
                    cmd.Parameters.AddWithValue("@BarCodeNo", member.BarcodeNo);
                    cmd.Parameters.AddWithValue("@CardId", member.CardId);
                    if (member.OccupationId == 0)
                        cmd.Parameters.AddWithValue("@OccupationId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@OccupationId", member.OccupationId);
                    cmd.Parameters.AddWithValue("@Gender", member.Gender);
                    cmd.Parameters.AddWithValue("@PersonalEmail", member.Email);
                    cmd.Parameters.AddWithValue("@PersonalMobile", member.Mobile);
                    cmd.Parameters.AddWithValue("@Image", member.Image);
                    if (member.Dob == DateTime.MinValue)
                        cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@DOB", member.Dob);
                    cmd.Parameters.AddWithValue("@CreatedBy", member.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    memberId = Convert.ToInt32(cmd.Parameters["@MemberId"].Value);
                    con.Close();
                }
            }
            return memberId;
        }

        public DataTable Member_GetAll(Model.Member member)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_Member_GetAll";
                        if (member.MemberId == 0)
                            cmd.Parameters.AddWithValue("@MemberId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                        if (string.IsNullOrEmpty(member.FirstName))
                            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Name", member.FirstName);
                        if (string.IsNullOrEmpty(member.BarcodeNo))
                            cmd.Parameters.AddWithValue("@BarCodeNo", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@BarCodeNo", member.BarcodeNo);
                        if (string.IsNullOrEmpty(member.CardId))
                            cmd.Parameters.AddWithValue("@CardId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@CardId", member.CardId);
                        if (string.IsNullOrEmpty(member.Gender))
                            cmd.Parameters.AddWithValue("@Gender", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Gender", member.Gender);
                        if (string.IsNullOrEmpty(member.Mobile))
                            cmd.Parameters.AddWithValue("@PersonalMobile", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@PersonalMobile", member.Mobile);
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

        public int Member_Delete(int memberId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Member_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", memberId);
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
