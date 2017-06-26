namespace SandboxCore11.Features.Shared
{
    using AutoMapper;
    using SandboxCore11.Data;
    using SandboxCore11.Features.Shared.Components.PendingOrdersWidget;

    public class SharedMappingProfile : Profile
    {
        public SharedMappingProfile()
        {
            // Pending orders widget
            CreateMap<PurchaseOrder, PendingOrderViewModel>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));
        }
    }
}
