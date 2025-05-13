using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_2025.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")] // Para identificar el nombre más fácil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] //Longitud máxima
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Campo obligatorio
        public String Name { get; set; }
    }
}
