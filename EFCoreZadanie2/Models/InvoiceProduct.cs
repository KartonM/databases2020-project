﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreZadanie2.Models
{
    public class InvoiceProduct
    {
        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Amount() => Product.UnitPrice * Quantity;
    }
}
