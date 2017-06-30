namespace SandboxCore11.Queries
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Brands
            CreateMap<Data.Brand, Brand>();

            // Categories
            CreateMap<Data.Category, Category>();

            // Inventory items
            CreateMap<Data.InventoryItem, InventoryItem>();

            // Purchase orders
            CreateMap<Data.PurchaseOrder, PurchaseOrder>();

            // Suppliers
            CreateMap<Data.Supplier, Supplier>();
        }
    }
}
