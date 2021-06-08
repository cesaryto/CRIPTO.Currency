using Currency.Database.Configuration;
using Currency.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Currency");

            ModelConfig(builder);
        }

        public DbSet<Coin> Coins { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new CoinConfiguration(modelBuilder.Entity<Coin>());
        }
    }
}
