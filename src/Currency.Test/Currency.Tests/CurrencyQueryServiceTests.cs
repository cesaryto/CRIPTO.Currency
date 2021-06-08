using Currency.Api.Controllers;
using Currency.Domain;
using Currency.Service.EventHandlers;
using Currency.Service.EventHandlers.Commands;
using Currency.Service.Queries;
using Currency.Service.Queries.DTOs;
using Currency.Service.Queries.Exceptions;
using Currency.Tests.Config;
using Currrency.Proxies;
using Currrency.Proxies.Currency;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Currency.Common.Enums;

namespace Currency.Tests
{
    /// <summary>
    /// Ejecuta las pruebas unitarias.
    /// </summary>
    [TestClass]
    public class CurrencyQueryServiceTests
    {
       
        /// <summary>
        /// Realiza la prueba unitaria de obtener una cripto moneda existente en BD
        /// </summary>
        [TestMethod]
        public void TryGetWhenCoinExist()
        {
            var context = ApplicationDbContextInMemory.Get();

            context.Coins.Add(
                    new Coin
                    {
                        id=90,
                        symbol= "BTC",
                        name= "Bitcoin" ,
                        nameid= "bitcoin",
                        rank=1,
                        price_usd= "35961.67",
                        percent_change_24h= "-0.61",
                        percent_change_1h= "-0.37",
                        percent_change_7d= "-0.63",
                        price_btc= "1.00",
                        market_cap_usd= "671132960269.19",
                        volume24=0,
                        volume24a=0,
                        csupply= "18662452.00",
                        tsupply= "18662452",
                        msupply= "21000000"
                    }
                );
            context.SaveChanges();

            var service = new CurrencyDbQueryService(context);
            CoinDto coin=service.GetAsync(90).GetAwaiter().GetResult();
            Assert.IsNotNull(coin);
        }

        /// <summary>
        /// Realiza la prueba unitaria de la excepción lanzada cuando no se encuentra una criptomoneda en BD
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CoinsException))]
        public void TryGetUsdWhenCoinDoesntExist()
        {
            var context = ApplicationDbContextInMemory.Get();
            var service = new CurrencyDbQueryService(context);
            try
            {
                CoinDto coin = service.GetAsync(6000).GetAwaiter().GetResult();
            }
            catch (Exception ae)
            {
                var exception = ae.GetBaseException();
                if (exception is CoinsException)
                {
                    throw new CoinsException(exception?.InnerException?.Message);
                }
            }
        }
        /// <summary>
        /// Realiza la prueba unitaria de obtener la conversión de dolares a cripto moneda cuando esta existe en BD
        /// </summary>
        [TestMethod]
        public void TryGetConvertUsdCurrencyWhenCoinExist()
        {
            var context = ApplicationDbContextInMemory.Get();
            var service = new CurrencyDbQueryService(context);
            context.Coins.Add(
                   new Coin
                   {
                       id = 90,
                       symbol = "BTC",
                       name = "Bitcoin",
                       nameid = "bitcoin",
                       rank = 1,
                       price_usd = "35961.67",
                       percent_change_24h = "-0.61",
                       percent_change_1h = "-0.37",
                       percent_change_7d = "-0.63",
                       price_btc = "1.00",
                       market_cap_usd = "671132960269.19",
                       volume24 = 0,
                       volume24a = 0,
                       csupply = "18662452.00",
                       tsupply = "18662452",
                       msupply = "21000000"
                   }
               );
            context.SaveChanges();
            decimal var = service.GetAsync(new CurrencyConvertUsdQuery
            {
                usd = Convert.ToDecimal("35961.67", CultureInfo.InvariantCulture),
                id = 90
            });

            Task.Delay(2000);

            Assert.AreEqual(Convert.ToDecimal(1, CultureInfo.InvariantCulture), var);
        }
        /// <summary>
        /// Realiza la prueba unitaria de la excepción lanzada al obtener la conversión de dolares a cripto moneda, cuando esta no se encuentra en BD
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CoinsException))]
        public void TryGetConvertUsdCurrencyWhenCoinDoesntExist()
        {
            var context = ApplicationDbContextInMemory.Get();
            var service = new CurrencyDbQueryService(context);
            try
            {
                decimal var = service.GetAsync(new CurrencyConvertUsdQuery
                {
                    usd = Convert.ToDecimal("35961.67", CultureInfo.InvariantCulture),
                    id = 6000
                });
            }
            catch (Exception ae)
            {
                var exception = ae.GetBaseException();
                if (exception is CoinsException)
                {
                    throw new CoinsException(exception?.InnerException?.Message);
                }
            }

          
        }


    }
}
