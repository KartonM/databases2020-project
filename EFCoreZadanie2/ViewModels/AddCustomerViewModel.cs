using System.ComponentModel.DataAnnotations;

namespace FruitAndVegetableWarehouseManagement.ViewModels
{
    public class AddCustomerViewModel
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Range(0, 100)]
        public int DiscountPercentage { get; set; }
    }
}
