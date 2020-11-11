using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TiendaServicios.Api.Libros.Aplicacion.Dtos;
using TiendaServicios.Api.Libros.Aplicacion.LibroHandler;
using TiendaServicios.Api.Libros.Modelo;
using TiendaServicios.Api.Libros.Persistencia;
using Xunit;

namespace TiendaServicios.Api.Libros.Test
{
    public class LibroServiceTest
    {
        private IEnumerable<Libro> GetDatosTest()
        {
            A.Configure<Libro>()
                .Fill(x => x.Titulo).AsArticleTitle()
                .Fill(x => x.LibroId).WithinRange(2, 1000000);

            var res = A.ListOf<Libro>(50);
            res[0].LibroId = 1;

            return res;
        }
        private Mock<ContextoLibro> CrearContexto()
        {
            var dataTest = GetDatosTest().AsQueryable();
            var dbSet = new Mock<DbSet<Libro>>();

            dbSet.As<IQueryable<Libro>>().Setup(x => x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<Libro>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<Libro>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<Libro>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());
            dbSet.As<IAsyncEnumerable<Libro>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken())).Returns(new AsyncEnumerator<Libro>(dataTest.GetEnumerator()));
            dbSet.As<IQueryable<Libro>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Libro>(dataTest.Provider));

            var mockContexto = new Mock<ContextoLibro>();
            mockContexto.Setup(x => x.Libro).Returns(dbSet.Object);

            return mockContexto;
        }
        [Fact]
        public async void GetLibros()
        {
            var mockContexto = CrearContexto();
            var mapCofig = new MapperConfiguration(x => { x.AddProfile(new MappingTest()); });
            var mapper = mapCofig.CreateMapper();
            var request = new LibroGetList.Request();
            var manejador = new LibroGetList.Handler(mockContexto.Object, mapper);

            var result = await manejador.Handle(request, new CancellationToken());

            Assert.True(result.Any());
        }
        [Fact]
        public async void GetLibro()
        {
            var mockContexto = CrearContexto();
            var mapCofig = new MapperConfiguration(x => { x.AddProfile(new MappingTest()); });
            var mapper = mapCofig.CreateMapper();
            var request = new LibroGet.Request() { LibroId = 1 };
            var manejador = new LibroGet.Handler(mockContexto.Object, mapper);

            var result = await manejador.Handle(request, new CancellationToken());

            Assert.NotNull(result);
            Assert.True(result.LibroId == 1);
        }
        [Fact]
        public async void InserLibro()
        {
            var options = new DbContextOptionsBuilder<ContextoLibro>()
                            .UseInMemoryDatabase("librodb")
                            .Options;
            var mockContexto = new ContextoLibro(options);            
            var request = new LibroInsert.Request() { Autor = Guid.Empty, FechaPublicacion = DateTime.Now, Titulo = "Test" };
            var manejador = new LibroInsert.Handler(mockContexto);

            var result = await manejador.Handle(request, new CancellationToken());

            Assert.True(result != null);
        }
    }
}
