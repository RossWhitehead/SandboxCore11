namespace SandboxCore11.Features.InventoryItems
{
    using AutoMapper;

    public class InventoryItemsMappingProfile : Profile
    {
        public InventoryItemsMappingProfile()
        {
            // Inventory Items create
            CreateMap<CreateEditModel, Commands.CreateInventoryItem.CreateInventoryItemCommand>();
        }
    }
}
