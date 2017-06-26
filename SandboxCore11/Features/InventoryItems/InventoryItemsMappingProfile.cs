namespace SandboxCore11.Features.InventoryItems
{
    using AutoMapper;
    using SandboxCore11.Commands;

    public class InventoryItemsMappingProfile : Profile
    {
        public InventoryItemsMappingProfile()
        {
            // Inventory Items create
            CreateMap<CreateEditModel, CreateInventoryItemCommand>();
        }
    }
}
