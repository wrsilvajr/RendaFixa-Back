using Moq;
using RendaFixa.Domain;
using RendaFixa.WebApi.Controllers;
using RendaFixa.Service;
using System;
using Xunit;
using AutoMapper;
using RendaFixa.WebApi.ViewModel;
using System.Web.Http;
using System.Threading.Tasks;

namespace RendaFixa.Test
{
    public class WebApiTest
    {

        private static IMapper _mapper;

        public WebApiTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new WebApi.App_Start.AutoMapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async void TestApi()
        {
            CDBViewModel vm = new CDBViewModel { Prazo = 1, ValorInicial = 10000 };
            var mockService = new Mock<ICDB>();
            //var mapperMock = new Mock<IMapper>();

            mockService.Setup(s => s.Calcular(new CDB(1000, 1))).Returns((CDB t) => { t.ValorLiquido = 11; t.ValorBruto = 12; });
            //mapperMock.Setup(m => m.Map<CDBViewModel, CDB>(It.IsAny<CDBViewModel>())).Returns((CDBViewModel src) => new CDB(1000,1));
            ////var entity = _cdbService.Calcular(mapper.Map<CDB>(vm));
            //var controller = new CDBController(mockService.Object, mapperMock.Object);

            //// Act
            //IHttpActionResult actionResult = await controller.Calcular(vm);

            ////// Assert
            ////Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            ///

            var controller = new CDBController(mockService.Object, _mapper);
            IHttpActionResult actionResult = await controller.Calcular(vm);

        }
    }
}
