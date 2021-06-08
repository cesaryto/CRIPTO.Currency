using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Domain
{
    public class CurrencyGlobal
    {
        public int coins_count { get; set; }
        public int active_markets { get; set; }
        public int total_mcap { get; set; }
        public int total_volume { get; set; }
        public string btc_d { get; set; }
        public string eth_d { get; set; }
        public string mcap_change { get; set; }
        public string volume_change { get; set; }
        public string avg_change_percent { get; set; }
        public int volume_ath { get; set; }
        public int mcap_ath { get; set; }
    }
}
