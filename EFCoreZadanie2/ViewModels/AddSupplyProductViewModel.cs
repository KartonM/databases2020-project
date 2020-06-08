using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FruitAndVegetableWarehouseManagement.Models;

namespace FruitAndVegetableWarehouseManagement.ViewModels
{
    public class AddSupplyProductViewModel
    {
        public Supply Supply { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SupplyId { get; set; }
        [Required]
        public int Kilograms { get; set; }
    }
}
