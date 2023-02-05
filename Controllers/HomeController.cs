using Microsoft.AspNetCore.Mvc;

namespace OwlNews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}