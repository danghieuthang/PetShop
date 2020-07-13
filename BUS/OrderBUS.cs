using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class OrderBUS
    {
        private OrderDAO _orderDAO;
        public OrderBUS()
        {
            _orderDAO = new OrderDAO();
        }
        public DataTable GetOrderByUser(string userName)
        {
            return _orderDAO.GetOrderByUser(userName);
        }
        public bool InsertOrder(OrderDTO dto)
        {
            return _orderDAO.InsertOrder(dto);
        }
    }
}
