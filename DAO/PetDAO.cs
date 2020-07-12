using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PetDAO:DBConection
    {
        public PetDAO()
        {

        }

        public DataTable GetPets()
        {
            DataTable result = new DataTable();
            string sql = "SELECT P.[ID], P.[Name], [TypeID], T.Name, [Price] FROM [dbo].[Pets] AS P JOIN Type AS T ON P.TypeID=T.ID ";
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

                throw new Exception("Error at GetPets");
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
