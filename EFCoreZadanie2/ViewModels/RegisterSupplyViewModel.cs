using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EFCoreZadanie2.Models;

namespace EFCoreZadanie2.ViewModels
{
    public class RegisterSupplyViewModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int SuppliedUnits { get; set; }
    }
}
