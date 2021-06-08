using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Service.Queries
{
    /// <summary>
    /// Representa el content para la solicitud de conversión de dolares a valor de cripto moneda
    /// </summary>
    public class CurrencyConvertUsdQuery
    {
        /// <summary>
        /// Identificador de criptomoneda
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Valor en dolares
        /// </summary>
        public decimal usd { get; set; }
    }
}
