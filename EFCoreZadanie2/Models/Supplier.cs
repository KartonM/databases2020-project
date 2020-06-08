using System.Collections.Generic;

namespace FruitAndVegetableWarehouseManagement.Models
{
    public class Supplier : Company
    {
        public string BankAccountNumber { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
