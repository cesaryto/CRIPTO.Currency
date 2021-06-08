using Currency.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Domain
{
    /// <summary>
    /// Modelo de datos de cripto monedas de coinlore.com
    /// </summary>
    public class ListaCoins
    {
        public List<Coin> data { get; set; }
        public Info info { get; set; }
    }
}
