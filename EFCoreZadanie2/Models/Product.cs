using System.Collections.Generic;

namespace FruitAndVegetableWarehouseManagement.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int KgsInStock { get; set; }
        public decimal PricePerKg { get; set; }

        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
