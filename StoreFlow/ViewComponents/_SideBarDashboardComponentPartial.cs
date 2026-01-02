using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponents
{
    public class _SideBarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
