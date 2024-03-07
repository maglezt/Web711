using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class ComprasDetalle
    {
        public int IdCompraDetalle { get; set; }
        public int IdCompraEncabezado { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }
}
