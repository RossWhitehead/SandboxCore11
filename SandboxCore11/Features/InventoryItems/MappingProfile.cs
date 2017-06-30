namespace SandboxCore11.Features.InventoryItems
{
    using AutoMapper;
    using SandboxCore11.Commands;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Queries.InventoryItem, DeleteViewModel>();
            CreateMap<Queries.InventoryItem, DetailsViewModel>();
            CreateMap<Queries.InventoryItem, EditViewModel>();
        }
    }
}
