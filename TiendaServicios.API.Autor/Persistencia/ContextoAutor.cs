using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autores.Modelo;

namespace TiendaServicios.Api.Autores.Persistencia
{
    public class ContextoAutor: DbContext
    {
        public DbSet<Modelo.Autor> Autor { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
        public ContextoAutor()
        {
        }
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options)
        {
        }
    }
}
