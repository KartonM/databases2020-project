using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreZadanie2.ViewModels
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
