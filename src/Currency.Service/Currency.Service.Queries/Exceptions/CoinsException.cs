using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Service.Queries.Exceptions
{
    /// <summary>
    /// Representa las excepciones que se lanzarán cuando las criptomonedas a consultar no existen en la BD
    /// </summary>
    public class CoinsException : Exception
    {
        public CoinsException(string message) : base(message)
        { 
        
        }
    }
}
