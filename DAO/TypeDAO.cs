using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TypeDAO: DBConection
    {
        public TypeDAO()
        {

        }

        public DataTable GetType()
        {
            DataTable result = new DataTable();
            string sql = "SELECT ID, Name FROM Type";
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

                throw new Exception("Error at GetType");
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
