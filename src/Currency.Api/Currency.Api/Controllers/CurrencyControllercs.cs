using Currency.Domain;
using Currency.Service.EventHandlers.Commands;
using Currency.Service.Queries;
using Currency.Service.Queries.DTOs;
using Currrency.Proxies;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Currency.Api.Controllers
{
    [ApiController]
    [Route("currencies")]

    public class CurrencyControllercs : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ICurrencyService _currencyQueryService;
        private readonly ICurrencyDbQueryService _currencyDbQueryService;

        /// <summary>
        /// Constructor del controlador
        /// </summary>
        /// <param name="mediator">Encapsulador de request y responses</param>
        /// <param name="currencyQueryService">Define el servicio para solicitudes al web api de cripto monedas coinlore.com</param>
        /// <param name="currencyDbQueryService">Define el servicio para consultas a la BD</param>
        public CurrencyControllercs(IMediator mediator, ICurrencyService currencyQueryService, ICurrencyDbQueryService currencyDbQueryService)
        {
            _mediator = mediator;
           _currencyQueryService = currencyQueryService;
            _currencyDbQueryService = currencyDbQueryService;
        }

        /// <summary>
        /// Método Post que obtiene todas las cripto monedas de la web api y los guarda en la BD
        /// </summary>
        /// <param name="command">Define el content para el request</param>
        /// <returns>ActionResut de la operación</returns>

        [HttpPost]
        public async Task<IActionResult> Create(CurrencyFillTableCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        /// <summary>
        /// Método Get que retorna todas las criptomonedas del web api de coinlore.com
        /// </summary>
        /// <returns>Obtiene todas las criptomonedas actualizadas</returns>
        [HttpGet]
        public async Task<ICollection<Coin>> Get()
        {

            return await _currencyQueryService.GetAsync();
        }

        /// <summary>
        /// Método GET que obtiene información de una criptomoneda de la BD por Id
        /// </summary>
        /// <param name="id">Identificador de la criptomoneda</param>
        /// <returns>CoinDto con los datos de la criptomoneda</returns>

        [HttpGet("GetById/{id}")]
        public async Task<CoinDto> Get(int id)
        {

            return await _currencyDbQueryService.GetAsync(id);
        }

        /// <summary>
        /// Método GET que obtiene el valor en una criptomoneda dada, dado un valor de dolares
        /// </summary>
        /// <param name="query">Define el content para el request</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{convert}")]
        public  decimal Get(CurrencyConvertUsdQuery query)
        {
            CoinDto dto = _currencyDbQueryService.GetAsync(query.id).GetAwaiter().GetResult();
            return query.usd / Convert.ToDecimal(dto.price_usd, CultureInfo.InvariantCulture);
        }
    }
}
