using System.Collections.Generic;
using System.Linq;

namespace FruitAndVegetableWarehouseManagement.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int KgsInStock { get; set; }
        public decimal SellingPricePerKg { get; set; }
        public decimal BuyingPricePerKg { get; set; }

        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
        public ICollection<SupplyProduct> SupplyProducts { get; set; }

        public string LastSupplyDateString() => SupplyProducts
            .OrderByDescending(sp => sp.Supply.Date)
            .FirstOrDefault()
            ?.Supply
            ?.DateTimeString();
    }
}
