using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class Etiqueta
    {
        public Etiqueta()
        {
            EtiquetasProductos = new HashSet<EtiquetasProducto>();
        }

        public int IdEtiquetas { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<EtiquetasProducto> EtiquetasProductos { get; set; }
    }
}
