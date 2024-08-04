using DevExtremeAspNetCoreApp1.Context;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeAspNetCoreApp1.Controllers
{
    public class KisilerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
