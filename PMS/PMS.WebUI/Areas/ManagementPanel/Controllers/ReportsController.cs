using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PMS.WebUI.Areas.ManagementPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("ManagementPanel")]

    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
