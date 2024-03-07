using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPrincipal.Models;

namespace WebPrincipal.Controllers
{
    public class EtiquetasController : Controller
    {
        /// <summary>
        /// objeto que se relaciona con el "Contexto" las clases que conforman el mapeo de la base de datos
        /// </summary>
        private readonly MS711Context _context;

        /// <summary>
        /// Crea una nueva instancia de la clase "EtiquetasController"
        /// </summary>
        /// <param name="context"></param>
        public EtiquetasController(MS711Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Etiquetas.ToListAsync());
        }

        public IActionResult Create() 
        {
            ViewData["Categorias"] = new SelectList(_context.Etiquetas, "IdEtiqueta", "Nombre");
            return View();
        }
    }
}
