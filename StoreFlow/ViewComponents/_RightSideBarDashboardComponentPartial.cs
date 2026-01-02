using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponents
{
    public class _RightSideBarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
