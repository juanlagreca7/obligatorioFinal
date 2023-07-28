using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVitalSignMonitor.Models
{
    [Table("Pacientes")]
    public class Dispositivo
    {
        [Key]
        public string IdDispositivo { get; set; }
        public Usuario Creador { get; set; }
        public Paciente Paciente { get; set; }
        [ForeignKey]
        public int PacienteId { get; set; }
        [Required(ErrorMessage = "Nombre del dispositivo es un campo obligatorio")]
        public string NombreDispositivo { get; set; }
        public string? Detalles { get; set; }
        [Required(ErrorMessage = "Debe asignarse un fecha de alta del dispositivo")]
        public DateTime FechaAlta { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public bool Estado { get; set; }
        public string Tokken { get; set; }
    }
}