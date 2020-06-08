using System.Collections.Generic;

namespace FruitAndVegetableWarehouseManagement.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
