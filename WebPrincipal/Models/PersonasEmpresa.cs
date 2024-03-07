using System;
using System.Collections.Generic;

namespace WebPrincipal.Models
{
    public partial class PersonasEmpresa
    {
        public int IdPersonaEmpresa { get; set; }
        public string Nombre { get; set; } = null!;
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string Tipo { get; set; } = null!;
        public DateTime? FechaHoraRegistro { get; set; }

        public virtual Proveedore? Proveedore { get; set; }
    }
}
