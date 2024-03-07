using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPrincipal.Models;
using WebPrincipal.Models.ViewModels;

namespace WebPrincipal.Controllers
{
    public class ProductosController : Controller
    {
        private readonly MS711Context _context;

        public ProductosController(MS711Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //var productos = _context.Productos.Include(p => p.EtiquetasProductos);
            var productos = (from p in _context.Productos
                             join ep in _context.EtiquetasProductos on p.IdProducto equals ep.IdProducto into lj
                             from res in lj.DefaultIfEmpty()
                             join e in _context.Etiquetas on res.IdEtiqueta equals e.IdEtiquetas into lj2
                             from res2 in lj2.DefaultIfEmpty()
                             select new ProductosViewModel
                             {
                                 Codigo = p.Codigo,
                                 Nombre = p.Nombre,
                                 Precio = p.Precio,
                                 Etiqueta = (res == null ? String.Empty : res2.Nombre)
                             }).OrderBy(o => o.Nombre);

            return View(await productos.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Etiquetas"] = new SelectList(_context.Etiquetas, "IdEtiquetas", "Nombre");
            return View();
        }

        [HttpPost]//
        [ValidateAntiForgeryToken]//Evita que la información que se va a indicar sea fuera del formulario
        public async Task<IActionResult> Create(ProductosViewModel model)
        {
            if(ModelState.IsValid)
            {
                var product = new ProductosViewModel()
                {
                    Codigo = model.Codigo,
                    Nombre = model.Nombre,
                    Precio = model.Precio//,
                    //Etiquetas = categoria
                };

                //_context.Productos.Add(product);
                await _context.SaveChangesAsync();//en este punto es cuando se guarda en la base de datos
                return RedirectToAction(nameof(Index));
            }

            ViewData["Etiquetas"] = new SelectList(_context.Etiquetas, "IdEtiquetas", "Nombre", model.Etiqueta);
            return View(model);
        }
    }
}
