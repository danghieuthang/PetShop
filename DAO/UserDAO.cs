using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO : DBConection
    {
        public UserDAO()
        {

        }
        public UserDTO CheckLogin(string username, string password)
        {
            UserDTO result = null;
            string sql = "SELECT FullName FROM [Users] WHERE UserName = @UserName AND Password = @Password";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataReader dr;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string name = dr["FullName"].ToString();

                    result = new UserDTO
                    {
                        UserName = username,
                        Password = password,
                        FullName = name
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
