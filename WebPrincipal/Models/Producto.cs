using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class Producto
    {
        public Producto()
        {
            EtiquetasProductos = new HashSet<EtiquetasProducto>();
            VentasDetalles = new HashSet<VentasDetalle>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string? Codigo { get; set; }

        public virtual ICollection<EtiquetasProducto> EtiquetasProductos { get; set; }
        public virtual ICollection<VentasDetalle> VentasDetalles { get; set; }
    }
}
