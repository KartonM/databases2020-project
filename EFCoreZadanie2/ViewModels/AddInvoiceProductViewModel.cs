using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EFCoreZadanie2.Models;

namespace EFCoreZadanie2.ViewModels
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
        public int Quantity { get; set; }
    }
}
