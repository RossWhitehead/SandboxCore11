namespace SandboxCore11.Commands
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Inventory item
            CreateMap<CreateInventoryItemCommand, Data.InventoryItem>();
            CreateMap<EditInventoryItemCommand, Data.InventoryItem>();
        }
    }
}
