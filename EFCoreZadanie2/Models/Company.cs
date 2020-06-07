using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreZadanie2.Models
{
    public abstract class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }

        public string Address() => $"{Street}, {ZipCode} {City}";
    }
}
