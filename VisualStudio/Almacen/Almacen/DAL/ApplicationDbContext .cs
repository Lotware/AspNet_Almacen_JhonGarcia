
using Almacen.Entidad;
using Microsoft.EntityFrameworkCore;

namespace Almacen.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Mov_Inventario> MovimientosInventario { get; set; }

        // Otros DbSet para otras entidades si es necesario

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí puedes configurar tus entidades si es necesario
            base.OnModelCreating(modelBuilder);
        }
    }
}
