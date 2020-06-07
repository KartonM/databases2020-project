using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreZadanie2.Models
{
    public class Supplier : Company
    {
        public string BankAccountNumber { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
