using System;

namespace Saiive.Alert.Check.Options
{
    public class AlertConfig
    {
        public TimeSpan Interval { get; set; } = TimeSpan.FromMinutes(10);
        public string SuperNodeUrl { get; set; } = "https://staging-supernode.defichain-wallet.com/";
        public string Network { get; set; } = "mainnet";
        public string Coin { get; set; } = "DFI";

        public string ExplorerBaseUrl { get; set; } = "https://explorer.defichain.com/";
        public string ExplorerTxPrefix { get; set; } = "#/DFI/mainnet/tx/";
    }
}
