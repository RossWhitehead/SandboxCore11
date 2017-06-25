namespace SandboxCore11.Features.Shared.Components.LatestProductsWidget
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class LatestProductsWidget : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
