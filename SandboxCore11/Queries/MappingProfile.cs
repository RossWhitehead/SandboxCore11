namespace SandboxCore11.Queries
{
    using AutoMapper;
    using SandboxCore11.Features.InventoryItems;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Inventory items
            CreateMap<Data.InventoryItem, InventoryItem>();
        }
    }
}
