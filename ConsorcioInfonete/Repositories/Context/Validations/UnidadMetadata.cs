using System.ComponentModel.DataAnnotations;

namespace Repositories.Context
{
    internal class UnidadMetadata
    {
        [Required (ErrorMessage = "El nombre de la unidad es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la unidad no puede tener más de {1} caracteres")]
        public string Nombre;

        [Required(ErrorMessage = "El nombre del propietario es requerido")]
        [StringLength(200, ErrorMessage = "El nombre del propietario no puede tener más de {1} caracteres")]
        public string NombrePropietario;

        [Required(ErrorMessage = "El apellido del propietario es requerido")]
        [StringLength(200, ErrorMessage = "El apellido del propietario no puede tener más de {1} caracteres")]
        public string ApellidoPropietario;

        [Required(ErrorMessage = "El email del propietario es requerido")]
        [EmailAddress (ErrorMessage = "El email es inválido")]
        public string EmailPropietario;

        [RegularExpression(@"^[-+]?[1-9]\d*$", ErrorMessage = "La superficie debe ser un entero")]
        public int Superficie;
    }
}