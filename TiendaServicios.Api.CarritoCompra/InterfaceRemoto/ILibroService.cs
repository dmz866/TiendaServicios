using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.ModeloRemoto;

namespace TiendaServicios.Api.CarritoCompra.InterfaceRemoto
{
    public interface ILibroService
    {
        Task<(bool Resultado, LibroRemoto Libro, string ErrorMessage)> Get(int id);
    }
}
