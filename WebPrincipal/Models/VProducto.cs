using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class VProducto
    {
        public int IdProducto { get; set; }
        public int IdEtiqueta { get; set; }
        public string? Codigo { get; set; }
        public string Producto { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}
