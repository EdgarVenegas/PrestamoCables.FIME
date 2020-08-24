using Microsoft.EntityFrameworkCore;
using PrestamoCables.FIME.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoCables.FIME.Infraestructure
{
    // Especificar el contexto a utilizar. "DbContext " 
    public class PrestamoCablesDbContext : DbContext
    {
        public PrestamoCablesDbContext(DbContextOptions<PrestamoCablesDbContext> options) : base (options)
        {

        }

        //Agregar todas las tablas / contexto
        //Al realizar la migración convertirá las clases en tablas. 

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cable> Cables { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

    }
}
