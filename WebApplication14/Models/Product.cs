using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
    }
}
