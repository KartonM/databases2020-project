using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreZadanie2.Models;

namespace EFCoreZadanie2.ViewModels
{
    public class AddInvoiceViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public int CustomerId { get; set; }
        public int InvoiceNumber { get; set; }
    }
}
