using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UserBUS
    {
        private readonly UserDAO _userDAO;
        public UserBUS()
        {
            _userDAO = new UserDAO();
        }
        public UserDTO CheckLogin(string username, string password)
        {
            return _userDAO.CheckLogin(username, password);
        }
    }
}
