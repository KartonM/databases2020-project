using System.ComponentModel.DataAnnotations;
using FruitAndVegetableWarehouseManagement.Models;

namespace FruitAndVegetableWarehouseManagement.ViewModels
{
    public class RegisterSupplyViewModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int SuppliedUnits { get; set; }
    }
}
