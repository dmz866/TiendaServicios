using System;
using System.Collections.Generic;

namespace TiendaServicios.Api.Autores.Modelo
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public ICollection<GradoAcademico> GradoAcademicos { get; set; }
        public string AutorGuid { get; set; }
    }
}
