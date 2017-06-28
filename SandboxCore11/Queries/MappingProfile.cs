namespace SandboxCore11.Queries
{
    using AutoMapper;
    using SandboxCore11.Features.InventoryItems;

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

            // Suppliers
            CreateMap<Data.Supplier, Supplier>();
        }
    }
}
