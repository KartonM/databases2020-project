using System.Collections.Generic;
using FruitAndVegetableWarehouseManagement.Models;

namespace FruitAndVegetableWarehouseManagement.ViewModels
{
    public class AddInvoiceViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public int CustomerId { get; set; }
        public int InvoiceNumber { get; set; }
    }
}
