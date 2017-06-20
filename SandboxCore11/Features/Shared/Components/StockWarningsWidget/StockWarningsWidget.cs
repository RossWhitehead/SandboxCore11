namespace SandboxCore11.Features.Shared.Components
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class StockWarningsWidget : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
