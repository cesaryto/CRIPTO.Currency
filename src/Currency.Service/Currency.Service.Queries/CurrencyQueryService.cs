using Currency.Domain;
using Currency.Service.EventHandlers.Commands;
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
        Task<TransformUsdCoin> GetAsync(CurrencyConvertUsdQuery query);
        Task<ICollection<Coin>> GetAsync();
    }
    public class IcurrencyQueryService : ICurrencyService
    {
        private readonly ICurrencyProxy _currencyProxy;

        public IcurrencyQueryService(ICurrencyProxy currencyProxy)
        {
            _currencyProxy = currencyProxy;
        }

        public async Task<TransformUsdCoin> GetAsync(CurrencyConvertUsdQuery query)
        {
            return await _currencyProxy.GetTransformUsdAsync(query);
        }

        public async Task<ICollection<Coin>> GetAsync()
        {
            return await _currencyProxy.GetCoinsAsync();
        }
    }
}
