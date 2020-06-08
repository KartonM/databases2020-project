using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FruitAndVegetableWarehouseManagement.Models;

namespace FruitAndVegetableWarehouseManagement.ViewModels
{
    public class AddProductViewModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal SellingPricePerKg { get; set; }
        [Required]
        public decimal BuyingPricePerKg { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
