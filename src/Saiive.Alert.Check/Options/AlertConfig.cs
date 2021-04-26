using System;
using System.Collections.Generic;

namespace Saiive.Alert.Check.Options
{
    public class AlertConfig
    {
        public TimeSpan Interval { get; set; } = TimeSpan.FromMinutes(10);
        public string SuperNodeUrl { get; set; } = "https://staging-supernode.defichain-wallet.com/";
        public string Network { get; set; } = "mainnet";
        public string Coin { get; set; } = "DFI";

        public List<string> PubKeys { get; set; } = new() {  "8e6cx8JGZ5cjEkYiWHrFV6C7VKJHuxxw3x:Masternode_1", "8SjheaoNsGUieobTgkCD3vWjRDrw5qMQFN:Masternode_2", "8XVuitUvR9KVjmieuwKjXSLZaoCX4zeNJo:Masternode_3" };
    }
}
