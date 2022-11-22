using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RendaFixa.Domain;
using RendaFixa.WebApi.ViewModel;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace RendaFixa.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Microsoft.AspNetCore.Mvc.Route("api/v{version:apiVersion}/cdb")]
    public class CDBController : ApiController
    {
        private readonly ICDB _cdbService;
        private readonly IMapper _mapper;

        public CDBController(ICDB cdbService, IMapper mapper)
        {
            _cdbService = cdbService;
            _mapper = mapper;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IHttpActionResult> Calcular(CDBViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var entity = _cdbService.Calcular(_mapper.Map<CDB>(vm));
                entity.ValorLiquido = Math.Round(entity.ValorLiquido, 2);
                entity.ValorBruto = Math.Round(entity.ValorBruto, 2);
                var result = _mapper.Map<CDBViewModel>(entity);

                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
