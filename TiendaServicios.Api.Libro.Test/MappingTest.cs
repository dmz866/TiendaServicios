using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TiendaServicios.Api.Libros.Aplicacion.Dtos;
using TiendaServicios.Api.Libros.Modelo;

namespace TiendaServicios.Api.Libros.Test
{
    public class MappingTest: Profile
    {
        public MappingTest()
        {
            CreateMap<Libro, LibroDto>();
        }
    }
}
