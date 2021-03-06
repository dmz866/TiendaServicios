﻿using System;

namespace TiendaServicios.Api.Libros.Aplicacion.Dtos
{
    public class LibroDto
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? Autor { get; set; }
    }
}
