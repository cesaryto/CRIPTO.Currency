using Currency.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Tests.Config
{
    public static class ApplicationDbContextInMemory
    {
        /// <summary>
        /// Configuración de la BD en memoria para las pruebas unitarias
        /// </summary>
        /// <returns>Contexto de la BD para pruebas unitarias</returns>
        public static ApplicationDbContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"Currency.Db")
                .Options;
            return new ApplicationDbContext(options);
        }
    }
}
