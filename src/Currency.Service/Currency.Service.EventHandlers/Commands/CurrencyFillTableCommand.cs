using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Currency.Common.Enums;

namespace Currency.Service.EventHandlers.Commands
{
    /// <summary>
    /// Representa el comando para obtener las cripto monedas y agregarlas en la BD
    /// </summary>
    public class CurrencyFillTableCommand : INotification
    {
        /// <summary>
        /// Enumeración del tipo de acción Crear o Actualizar la BD, para fines de la prueba solo utilizo Crear
        /// </summary>
        public CurrencyTableTask TaskType { get; set; }

    }
}
