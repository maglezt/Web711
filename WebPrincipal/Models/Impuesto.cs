using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class Impuesto
    {
        public int IdCatalogoImpuestos { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Tasa { get; set; }
    }
}
