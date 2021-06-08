using Currency.Database;
using Currency.Domain;
using Currency.Service.EventHandlers.Commands;
using Currrency.Proxies.Currency;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Currency.Service.EventHandlers
{
    /// <summary>
    /// Clase para ejecutar los comandos recibidos
    /// </summary>
    public class CurrencyFillTableEventHandler : INotificationHandler<CurrencyFillTableCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrencyProxy _currencyProxy;

        /// <summary>
        /// Constructor del EventHandler
        /// </summary>
        /// <param name="context">Define el DbContext para guardar los datos de criptomonedas obtenidos de coinlore.com</param>
        /// <param name="currencyProxy">Define el servicio que realiza las peticiones a coinlore.com</param>
        public CurrencyFillTableEventHandler(
            ApplicationDbContext context,
            ICurrencyProxy currencyProxy
            )
        {
            _context = context;
            _currencyProxy = currencyProxy;
        }

        /// <summary>
        /// Método para ejecutar el comando que obtiene las criptomonedas de coinlore.com y las guarda en BD
        /// </summary>
        /// <param name="notification">Comando para obtener las criptomonedas de coinlore.com y guardarlas en BD</param>
        /// <param name="cancellationToken">Notificación para cancelar la operación</param>
    
        public async Task Handle(CurrencyFillTableCommand notification, CancellationToken cancellationToken)
        {
            using (var trx=await _context.Database.BeginTransactionAsync())
            {
                ICollection<Coin> coins = await _currencyProxy.GetCoinsAsync();

                if (notification.TaskType == Common.Enums.CurrencyTableTask.Create)
                {
                    await _context.AddRangeAsync(coins);                       
                }

                await _context.SaveChangesAsync();
                await trx.CommitAsync();
            }           
        }
    }
}
