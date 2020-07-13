using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class OrderDAO: DBConection
    {
        public OrderDAO()
        {

        }
        public DataTable GetOrderByUser(string userName)
        {
            DataTable result = new DataTable();
            string sql = "SELECT";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                adapter.Fill(result);
            }
            catch (Exception)
            {

                throw new Exception("Error at GetOrderByUser");
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public bool InsertOrder(OrderDTO dto)
        {
            bool result = false;
            string sql = "INSERT INTO Orders(PetID, UserName, Amount, TotalPrice) " +
                "VALUES(@PetID, @UserName, @Amount, @TotalPrice)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PetID", dto.Pet.ID);
            cmd.Parameters.AddWithValue("@UserName", dto.User.UserName);
            cmd.Parameters.AddWithValue("@Amount", dto.Amount);
            cmd.Parameters.AddWithValue("@TotalPrice", dto.TotalPrice);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                
                result= cmd.ExecuteNonQuery()>0;
            }
            catch (Exception e)
            {

                throw new Exception("Error at InsertOrder: "+e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
