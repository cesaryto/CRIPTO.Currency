using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currrency.Proxies
{
    /// <summary>
    /// Obtiene de appsettings las Url de coinlore.com
    /// </summary>
    public class ApiUrls
    {
        /// <summary>
        /// Url para obtener varias cripto monedas de coinlore.com
        /// </summary>
        public string CoinsUrl { get; set; }
        /// <summary>
        /// Url para obtener una cripto monedas de coinlore.com
        /// </summary>
        public string CoinUrl { get; set; }
        /// <summary>
        /// Url para obtener datos globales de las cripto monedas de coinlore.com
        /// </summary>
        public string CoinsGlobalUrl { get; set; }
    }
}
