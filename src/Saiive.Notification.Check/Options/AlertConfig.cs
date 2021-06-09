using System;

namespace Saiive.Notification.Check.Options
{
    public class AlertConfig
    {
        public TimeSpan Interval { get; set; } = TimeSpan.FromMinutes(10);
        public string SuperNodeUrl { get; set; } = "https://supernode.saiive.live/";

        public string ExplorerBaseUrl { get; set; } = "https://explorer.defichain.com/";
        public string ExplorerTxPrefix { get; set; } = "#/DFI/{0}/tx/";
    }
}
