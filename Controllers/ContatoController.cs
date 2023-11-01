using Microsoft.AspNetCore.Mvc;

namespace Lancheria.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
