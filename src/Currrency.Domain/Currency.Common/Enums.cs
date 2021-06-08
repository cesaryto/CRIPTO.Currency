using System;

namespace Currency.Common
{
    /// <summary>
    /// Contiene las enumeraciones utilizadas para el llenado y actualización de la tabla de Coins en DB
    /// </summary>
    public class Enums
    {
        public enum CurrencyTableTask
        { 
            Create,
            Update
        }
    }
}
