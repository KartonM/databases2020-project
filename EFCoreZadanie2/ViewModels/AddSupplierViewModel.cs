using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreZadanie2.ViewModels
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
