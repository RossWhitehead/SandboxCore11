namespace SandboxCore11.Commands
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create Inventory item
            CreateMap<CreateInventoryItemCommand, Data.InventoryItem>();
        }
    }
}
