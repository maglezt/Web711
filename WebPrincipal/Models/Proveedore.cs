using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            ComprasEncabezados = new HashSet<ComprasEncabezado>();
        }

        public int IdProveedor { get; set; }
        public int IdPersonaEmpresa { get; set; }

        public virtual PersonasEmpresa IdPersonaEmpresaNavigation { get; set; } = null!;
        public virtual ICollection<ComprasEncabezado> ComprasEncabezados { get; set; }
    }
}
