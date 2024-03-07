using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class ComprasEncabezado
    {
        public int IdCompraEncabezado { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaHoraRegistro { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }

        public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
    }
}
