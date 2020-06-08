using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitAndVegetableWarehouseManagement.Models
{
    public class SupplyProduct
    {
        public int SupplyId { get; set; }
        public Supply Supply { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Kilograms { get; set; }

        public decimal Cost() => Product.BuyingPricePerKg * Kilograms;
    }
}
