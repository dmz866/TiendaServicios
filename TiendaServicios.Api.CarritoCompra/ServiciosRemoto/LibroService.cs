using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.InterfaceRemoto;
using TiendaServicios.Api.CarritoCompra.ModeloRemoto;

namespace TiendaServicios.Api.CarritoCompra.ServiciosRemoto
{
    public class LibroService : ILibroService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LibroService> _logger;
        public LibroService(IHttpClientFactory httpClient, ILogger<LibroService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<(bool Resultado, LibroRemoto Libro, string ErrorMessage)> Get(int id)
        {
            try
            {
                var client = _httpClient.CreateClient("Libros");
                var response = await client.GetAsync($"api/Libro/{id}");

                if(response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LibroRemoto>(contenido, options);

                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString()); 
                return (false, null, ex.Message);
            }
        }
    }
}
