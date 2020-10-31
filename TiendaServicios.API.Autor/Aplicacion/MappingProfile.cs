using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autores.Aplicacion.Dtos;
using TiendaServicios.Api.Autores.Modelo;

namespace TiendaServicios.Api.Autores.Aplicacion
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Autor, AutorDto>();
        }
    }
}
