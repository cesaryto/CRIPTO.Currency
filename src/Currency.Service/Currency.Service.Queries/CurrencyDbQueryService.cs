using Currency.Common;
using Currency.Database;
using Currency.Domain;
using Currency.Service.Queries.DTOs;
using Currency.Service.Queries.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Service.Queries
{
    public interface ICurrencyDbQueryService
    {
        decimal GetAsync(CurrencyConvertUsdQuery query);
        Task<CoinDto> GetAsync(int id);
    }

    /// <summary>
    /// Servicio para obtener la información de monedas de la BD
    /// </summary>
    public class CurrencyDbQueryService : ICurrencyDbQueryService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor del Servicio para obtener la información de monedas de la BD
        /// </summary>
        /// <param name="context">Contexto de la BD</param>
        public CurrencyDbQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una moneda dado si identificador
        /// </summary>
        /// <param name="id">Identificador de la moneda</param>
        /// <returns>Dto que representa la moneda obtenida de la BD</returns>
        public async Task<CoinDto> GetAsync(int id)
        {
            try
            {
                CoinDto coin = (await _context.Coins.SingleAsync(x => x.id == id)).MapTo<CoinDto>();

                return coin;
            }
            catch
            {
                throw new CoinsException($"Coin {id} - doesn't exist in database");
            }
        }

        /// <summary>
        /// Obtiene la conversión a la criptomoneda dada, dado un valor en dolares
        /// </summary>
        /// <param name="query">representa el content para la solicitud de conversión a criptomoneda</param>
        /// <returns>valor convertido a criptomoneda</returns>
        public  decimal GetAsync(CurrencyConvertUsdQuery query)
        {
            string strValueUsd = string.Empty; 
            try
            {
                strValueUsd = _context.Coins.SingleAsync(x => x.id == query.id).Result.price_usd;
            }
            catch
            {
                throw new CoinsException($"Coin {query.id} - doesn't exist in database");
            }
             
            return query.usd / Convert.ToDecimal(strValueUsd, CultureInfo.InvariantCulture);           
        }
    }
}
