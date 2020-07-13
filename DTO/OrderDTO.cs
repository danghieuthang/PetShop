using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public PetDTO Pet { get; set; }
        public UserDTO User { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
