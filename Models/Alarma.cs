using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVitalSignMonitor.Models
{
    [Table("Alarmas")]
    public class Alarma
    {
        [Key]
        public string IdAlarma { get; set; }
        public Usuario Creador { get; set; }
        public Paciente Paciente { get; set; }  
        public Dispositivo Dispositivo { get; set; }
        [Required(ErrorMessage = "Es obligatorio definir un valor a comparar")]
        public float ValorComparativo { get; set; }
        public TipoAlarma TipoAlarma { get; set; }
        public TipoComparacion TipoComparacion { get; set; }
        [Required(ErrorMessage = "Es obligatorio definir una fecha de creacion")]
        public DateTime FechaCreacion { get; set; }
    }
}