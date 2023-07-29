using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVitalSignMonitor.Models
{
    [Table("Reportes")]
    public class Reporte
    {
        [Key]
        public string IdDispositivo { get; set; }
        public Paciente Paciente { get; set; }
        public Dispositivo Dispositivo { get; set; }
        public float? PresionDiastolica { get; set; }
        public float? PresionSistolica { get; set; }
        public int? SaturacionOxigeno { get; set; }
        public float? Temperatura { get; set; }
        public int? Pulso { get; set; }  
        public DateTime HoraFecha { get; set; }
    }
}