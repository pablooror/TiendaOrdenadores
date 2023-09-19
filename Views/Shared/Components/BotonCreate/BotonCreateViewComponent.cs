using Microsoft.AspNetCore.Mvc;

namespace ComponentesMVC.Views.Shared.Components.BotonCreate
{
    public class BotonCreateViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("Default"));
        }
    }
}
