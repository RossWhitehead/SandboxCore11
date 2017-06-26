namespace SandboxCore11.Features.InventoryItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using SandboxCore11.Data;
    using SandboxCore11.Features.InventoryItems;

    public class InventoryItemsMappingProfile : Profile
    {
        public InventoryItemsMappingProfile()
        {
            // Inventory Items create
            CreateMap<CreateEditModel, InventoryItem>();
        }
    }
}
