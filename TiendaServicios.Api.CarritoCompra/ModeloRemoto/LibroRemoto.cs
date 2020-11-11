using System;

namespace TiendaServicios.Api.CarritoCompra.ModeloRemoto
{
    public class LibroRemoto
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? Autor { get; set; }
    }
}
