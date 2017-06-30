namespace SandboxCore11.Features.InventoryItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using SandboxCore11.Queries;

    public class EditViewModel
    {
        public int InventoryItemId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        [Remote("ValidateName", "InventoryItems", AdditionalFields = "CurrentName")]
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

        public List<Brand> Brands { get; set; }

        public List<Category> Categories { get; set; }

        public List<SelectListItem> BrandSelectItems
        {
            get
            {
                return Brands.Select(b => new SelectListItem { Text = b.Name, Value = b.BrandId.ToString() }).ToList();
            }
        }

        public List<SelectListItem> CategorySelectItems
        {
            get
            {
                return Categories.Select(c => new SelectListItem { Text = c.Name, Value = c.CategoryId.ToString() }).ToList();
            }
        }
    }
}
