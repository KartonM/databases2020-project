using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitAndVegetableWarehouseManagement.Models
{
    public class Supply
    {
        public int SupplyId { get; set; }
        public DateTime Date { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<SupplyProduct> SupplyProducts { get; set; }

        public string DateTimeString() => $"{Date.ToShortDateString()}, {Date.ToShortTimeString()}";

        public decimal Cost() => SupplyProducts?.Sum(sp => sp.Cost()) ?? decimal.Zero;
    }
}
