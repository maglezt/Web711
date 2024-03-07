using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class EtiquetasProducto
    {
        public int IdEtiquetaProducto { get; set; }
        public int IdEtiqueta { get; set; }
        public int IdProducto { get; set; }

        public virtual Etiqueta IdEtiquetaNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
