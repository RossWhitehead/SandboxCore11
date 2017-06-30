namespace SandboxCore11.Commands
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Inventory items
            CreateMap<CreateInventoryItemCommand, Data.InventoryItem>();
            CreateMap<EditInventoryItemCommand, Data.InventoryItem>();

            // Purchase orders
            CreateMap<CreatePurchaseOrderCommand, Data.PurchaseOrder>();
            CreateMap<PurchaseOrderDetail, Data.PurchaseOrderDetail>();
        }
    }
}
