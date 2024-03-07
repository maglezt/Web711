using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class VentasEncabezado
    {
        public VentasEncabezado()
        {
            VentasDetalles = new HashSet<VentasDetalle>();
        }

        public int IdVentaEncabezado { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int? NumeroVenta { get; set; }

        public virtual ICollection<VentasDetalle> VentasDetalles { get; set; }
    }
}
