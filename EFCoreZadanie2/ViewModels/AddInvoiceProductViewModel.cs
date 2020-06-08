using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FruitAndVegetableWarehouseManagement.Models;

namespace FruitAndVegetableWarehouseManagement.ViewModels
{
    public class AddInvoiceProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Invoice Invoice { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public int Kilograms { get; set; }
    }
}
