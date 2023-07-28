using System.ComponentModel.DataAnnotations.Schema;

namespace AppVitalSignMonitor.Models
{
    [Table("Medicos")]
    public class Medico : Usuario
    {
        public string Especialidad { get; set; }
        public string Matricula { get; set; }
    }
}