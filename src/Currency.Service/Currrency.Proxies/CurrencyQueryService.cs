using Currency.Domain;
using Currency.Service.Queries;
using Currrency.Proxies.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currrency.Proxies
{
    public interface ICurrencyService
    {
        Task<ICollection<Coin>> GetAsync();
        Task<Coin> GetCoinAsync(int id);
    }
    /// <summary>
    /// Servicio para obtener cripto monedas de coinlore.com
    /// </summary>
    public class CurrencyQueryService : ICurrencyService
    {
        private readonly ICurrencyProxy _currencyProxy;

        /// <summary>
        /// constructor para el servicio de solicitudes a coinlore.com
        /// </summary>
        /// <param name="currencyProxy">Define la conexión a coinlore.com</param>
        public CurrencyQueryService(ICurrencyProxy currencyProxy)
        {
            _currencyProxy = currencyProxy;
        }

        /// <summary>
        /// Obtiene criptomonedas de coinlore.com en Batch
        /// </summary>
        /// <returns>Colección de criptomonedas de coinlore.com</returns>
        public async Task<ICollection<Coin>> GetAsync()
        {
            return await _currencyProxy.GetCoinsAsync();
        }

        /// <summary>
        /// Obtiene crripto moneda de coinlore.com dado su identificador
        /// </summary>
        /// <param name="id">Identificador de cripto moneda</param>
        /// <returns></returns>
        public async Task<Coin> GetCoinAsync(int id)
        {
            return await _currencyProxy.GetCoinAsync(id);
        }
    }
}
