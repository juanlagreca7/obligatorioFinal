using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVitalSignMonitor.Models
{
    [Table("Usuarios")]
    public abstract class Usuario
    {
        [Key]
        public string IdUsuario { get; set; }
        [Required(ErrorMessage = "Nombre de usuario es un campo obligatorio")]
        public string NombreUsuario { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Contraseña es un campo obligatorio")]
        public string Contrasena { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public Rol Rol { get; set; }
    }
}