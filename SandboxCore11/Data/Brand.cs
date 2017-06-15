using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore11.Data
{
    public class Brand
    {
        public int BrandId { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
    }
}
