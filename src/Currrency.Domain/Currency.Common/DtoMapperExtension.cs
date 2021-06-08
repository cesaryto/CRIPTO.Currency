using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Currency.Common
{
    public static class DtoMapperExtension
    {
        /// <summary>
        /// Mapper para convertir Coin a CoinDto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T MapTo<T>(this object value)
        {
            return JsonSerializer.Deserialize<T>(
                    JsonSerializer.Serialize(value)
                );
        }
    }
}
