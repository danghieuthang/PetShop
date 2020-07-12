using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PetDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TypeDTO Type { get; set; }
        public decimal Price { get; set; }
    }
}
