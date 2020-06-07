using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreZadanie2.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
