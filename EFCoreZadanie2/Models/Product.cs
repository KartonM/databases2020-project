using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreZadanie2.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
