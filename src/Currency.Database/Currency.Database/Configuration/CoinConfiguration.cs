using Currency.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Database.Configuration
{
    public class CoinConfiguration
    {
        /// <summary>
        /// Configuración de la creación de tabla Coin in DB
        /// </summary>
        /// <param name="entityBuilder">Builder para la creación de tabla Coin</param>
        public CoinConfiguration(EntityTypeBuilder<Coin> entityBuilder)
        {
            entityBuilder.HasKey(X => X.coinId);
        }
    }
}
