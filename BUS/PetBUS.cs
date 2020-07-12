using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PetBUS
    {
        private readonly PetDAO _petDAO;
        public PetBUS()
        {
            _petDAO = new PetDAO();
        }
        public DataTable GetPets()
        {
            return _petDAO.GetPets();
        }
    }
}
