using System.ComponentModel.DataAnnotations;

namespace WebPrincipal.Models.ViewModels
{
    public class ProductosViewModel
    {
        [Required]
        [Display(Name="Codigo de barras")]
        public string? Codigo { get; set; }

        [Required]
        [Display(Name = "Producto")]
        public string? Nombre { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string? Etiqueta { get; set; }
    }
}
