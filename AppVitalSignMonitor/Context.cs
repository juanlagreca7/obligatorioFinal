using AppVitalSignMonitor.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace AppVitalSignMonitor
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppVitalSignMonitor.Models.Administrador>? Administrador { get; set; }
        public DbSet<AppVitalSignMonitor.Models.Medico>? Medico { get; set; }
        public DbSet<AppVitalSignMonitor.Models.Usuario>? Usuario { get; set; }
        public DbSet<AppVitalSignMonitor.Models.Dispositivo>? Dispositivo { get; set; }
        public DbSet<AppVitalSignMonitor.Models.Alarma>? Alarma { get; set; }
        public DbSet<AppVitalSignMonitor.Models.Reporte>? Reporte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
        .Entity<Dispositivo>()
        .HasOne(e => e.Paciente)
        .WithMany()
        .OnDelete(DeleteBehavior.Restrict);
           base.OnModelCreating(modelBuilder);
        }


        //Models aqui.
    }

}
