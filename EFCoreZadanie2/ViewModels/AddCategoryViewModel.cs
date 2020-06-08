using System.ComponentModel.DataAnnotations;

namespace FruitAndVegetableWarehouseManagement.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
