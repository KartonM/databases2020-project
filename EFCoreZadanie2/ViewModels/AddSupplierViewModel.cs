using System.ComponentModel.DataAnnotations;

namespace FruitAndVegetableWarehouseManagement.ViewModels
{
    public class AddSupplierViewModel
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
        public string BankAccountNumber { get; set; }
    }
}
