using Microsoft.AspNetCore.Mvc;

namespace gawra.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
