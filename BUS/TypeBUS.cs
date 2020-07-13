using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TypeBUS
    {
        private readonly TypeDAO _typeDAO;
        public TypeBUS()
        {
            _typeDAO = new TypeDAO();
        }

        public DataTable GetType()
        {
            return _typeDAO.GetType();
        }

    }
}
