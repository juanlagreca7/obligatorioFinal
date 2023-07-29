using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVitalSignMonitor.Models
{
    [Table("Pacientes")]
    public class Paciente: Usuario
    {
      
        public DateTime FechaNacimiento { get; set; }
        public string GrupoSanguineo { get; set; }
        public string Detalles { get; set; }
        public Dispositivo Dispositivo { get; internal set; }
    }
}

// script migrations para ver los scripts