using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitAndVegetableWarehouseManagement.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }

        public string DateTimeString() => $"{Date.ToShortDateString()}, {Date.ToShortTimeString()}";

        public decimal Amount()
        {
            var sum = InvoiceProducts?.Sum(ip => ip.Amount()) ?? decimal.Zero;
            var discountFactor = Convert.ToDecimal(100 - Customer.DiscountPercentage) / 100;

            return sum * discountFactor;
        }
    }
}
