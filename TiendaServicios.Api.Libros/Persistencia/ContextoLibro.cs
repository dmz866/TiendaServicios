using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libros.Modelo;

namespace TiendaServicios.Api.Libros.Persistencia
{
    public class ContextoLibro: DbContext
    {
        public DbSet<Libro> Libro { get; set; }
        public ContextoLibro()
        {
        }
        public ContextoLibro(DbContextOptions<ContextoLibro> options): base(options)
        {
        }
    }
}
