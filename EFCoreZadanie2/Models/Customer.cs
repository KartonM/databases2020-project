using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreZadanie2.Models
{
    public class Customer : Company
    {
        [Range(0, 100)]
        public int DiscountPercentage { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        public string DiscountString() =>
            DiscountPercentage > 0 ? $"{DiscountPercentage}%" : "brak";

        public decimal InvoicesSum() => Invoices.Sum(i => i.Amount());
    }
}
