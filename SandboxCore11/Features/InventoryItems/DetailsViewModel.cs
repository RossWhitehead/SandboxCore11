namespace SandboxCore11.Features.InventoryItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using SandboxCore11.Data;

    public class DetailsViewModel
    {
        public int InventoryItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ReorderLevel { get; set; }

        public int ReorderQuantity { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }
    }
}
