using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DBConection
    {
        protected SqlConnection conn = new SqlConnection("server=.;database=PetShopDB;uid=sa;pwd=12345678");

    }
}
