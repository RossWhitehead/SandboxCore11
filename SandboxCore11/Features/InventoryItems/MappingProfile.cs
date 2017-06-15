using AutoMapper;
using SandboxCore11.Data;
using SandboxCore11.Features.InventoryItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandboxCore11.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Inventory Items create
            CreateMap<CreateEditModel, InventoryItem>();
        }
    }
}
