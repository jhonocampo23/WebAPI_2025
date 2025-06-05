using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_2025.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")] // Para identificar el nombre más fácil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] //Longitud máxima
        [Required(ErrorMessage = "El campo {0} es obligatorio")] // Campo obligatorio
        public string Name { get; set; }

        //Así es como relaciono dos tablas con Entitie Framework core
        [Display(Name = "País")]
        public Country? Country { get; set; }

        //Foreign key
        [Display(Name = "Id País")]
        public Guid CountryId { get; set; }

    }
}
