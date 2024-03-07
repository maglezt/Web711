using Microsoft.AspNetCore.Mvc;

namespace WebPrincipal.Controllers
{
    public class PersonasEmpresasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
