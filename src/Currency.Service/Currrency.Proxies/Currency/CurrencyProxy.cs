
using Currency.Common;
using Currency.Domain;
using Currency.Service.Queries;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Int32Converter = Currency.Common.Int32Converter;

namespace Currrency.Proxies.Currency
{
    public interface ICurrencyProxy
    {
        Task<ICollection<Coin>> GetCoinsAsync();
        Task<Coin> GetCoinAsync(int id);
    }
    /// <summary>
    /// Servicio para obtener los datos de coinlore.com
    /// </summary>
    public class CurrencyProxy : ICurrencyProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;
        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();

        /// <summary>
        /// Constructor del servicio para obtener los datos de coinlore.com
        /// </summary>
        /// <param name="httpClient">Cliente http para realzar solicitudes a coinlore.com</param>
        /// <param name="apiUrls">Objeto para obtener las urls de coinlore.com</param>
        public CurrencyProxy(HttpClient httpClient,
            IOptions<ApiUrls> apiUrls
            )
        {
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
            jsonSerializerOptions.Converters.Add(new Int32Converter());

        }

        /// <summary>
        /// Obtiene las cripto monedas de coinlore.com
        /// </summary>
        /// <returns>Colección de monedas obtenidas de coinlore.com</returns>
        public async Task<ICollection<Coin>> GetCoinsAsync()
        {
            //Obtenemos los datos generales de criptomonedas coinlore.com, para conocer el número de monedas existentes
            var client = await _httpClient.GetAsync(_apiUrls.CoinsGlobalUrl);
            string responseBody = await client.Content.ReadAsStringAsync();
            List<CurrencyGlobal> coinsGlobal = JsonSerializer.Deserialize<List<CurrencyGlobal>>(responseBody, jsonSerializerOptions);
            int icall = coinsGlobal[0].coins_count / 100;
            //obtenemos un enumerador para hacer peticiones en paralelo a coinlore.com
            List<int> n = new List<int>();
            for(int i = 0; i <= icall; i++)
            {
                n.Insert(i, i);
            }
            var sp= await GetCoinsParallel(n);
            List<ListaCoins> lt = sp.ToList();
            List<Coin> lc=lt.SelectMany(x => x.data).ToList();
            return lc;
        }
        /// <summary>
        /// Obtiene una cripto moneda de coinlore.com
        /// </summary>
        /// <param name="id">Identificador de la cripto moneda</param>
        /// <returns>Criptomoneda de coinlore.com</returns>
        public async Task<Coin> GetCoinAsync(int id)
        {
            string url = _apiUrls.CoinUrl + $"{id}";
            var response = await _httpClient.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();
            
            List<Coin> lstCoins = JsonSerializer.Deserialize<List<Coin>>(responseBody, jsonSerializerOptions);
            return lstCoins[0];
        }

        /// <summary>
        /// Realiza peticiones en paralelo de coinlore.com ya que obtiene solo 100 por petición
        /// </summary>
        /// <param name="coinsBatchIds">Se utiliza para armar los paths de las solicitudes a coinlore.com</param>
        /// <returns>Enumerable con todas las criptomonedas de coinlore.com</returns>

        public async Task<IEnumerable<ListaCoins>> GetCoinsParallel(IEnumerable<int> coinsBatchIds)
        {
            var tasks = coinsBatchIds.Select(id => GetCoins(id));
            var coins = await Task.WhenAll(tasks);
            return coins;
        }
        /// <summary>
        /// Obtiene lista de maximo 100 monedas de coinlore.com
        /// </summary>
        /// <param name="id">utilizado para armar el path de solicitud a coinlore.com</param>
        /// <returns>Lista de cripto monedas de coinlore.com</returns>
        public async Task<ListaCoins> GetCoins(int id)
        {
            
            var response = await _httpClient
                .GetAsync(
                    _apiUrls.CoinsUrl + $"/?start={id * 100}&limit=100")
                .ConfigureAwait(false);

            var coins = JsonSerializer.Deserialize<ListaCoins>(await response.Content.ReadAsStringAsync(), jsonSerializerOptions);


            return coins;
        }

    }
}
