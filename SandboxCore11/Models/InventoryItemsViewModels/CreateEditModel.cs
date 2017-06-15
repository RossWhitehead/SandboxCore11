using Microsoft.AspNetCore.Mvc.Rendering;
using SandboxCore11.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore11.Models.InventoryItemsViewModels
{
    public class CreateEditModel
    {
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required]
        public int ReorderQuantity { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
