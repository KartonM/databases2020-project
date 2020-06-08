using System.Collections.Generic;
using FruitAndVegetableWarehouseManagement.Models;

namespace FruitAndVegetableWarehouseManagement.ViewModels
{
    public class StatsViewModel
    {
        public decimal MonthlySum { get; set; }
        public IEnumerable<KeyValuePair<Customer, decimal>> MonthlyBestCustomers { get; set; }
        public decimal WeeklySum { get; set; }
        public IEnumerable<KeyValuePair<Customer, decimal>> WeeklyBestCustomers { get; set; }
        public IEnumerable<Product> MostUnitsInStock { get; set; }
        public IEnumerable<KeyValuePair<Supplier, IEnumerable<Product>>> SuppliersWithProductsRunOutOfStock { get; set; }
    }
}
