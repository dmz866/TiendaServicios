using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libros.Aplicacion.Dtos;
using TiendaServicios.Api.Libros.Modelo;

namespace TiendaServicios.Api.Libros.Aplicacion
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Libro, LibroDto>();
        }
    }
}
