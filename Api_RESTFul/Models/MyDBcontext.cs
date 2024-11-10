using Microsoft.EntityFrameworkCore;

namespace Api_RESTFul.Models
{
    public class MyDBcontext : DbContext
    {
        // CONSTRUCTOR:
        public MyDBcontext(DbContextOptions<MyDBcontext> options)
            : base(options)
        {

        }


        // TABLAS A MAPEAR EN LA DB:
        public DbSet<TipoEstacionamiento> TiposEstacionamientos { get; set; }
        public DbSet<AlquilerEstacionamiento> AlquilerEstacionamiento { get; set; }

    }
}
