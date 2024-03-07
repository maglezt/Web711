using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class VentasDetalle
    {
        public int IdVentaDetalle { get; set; }
        public int IdVentaEncabezado { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual VentasEncabezado IdVentaEncabezadoNavigation { get; set; } = null!;
    }
}
