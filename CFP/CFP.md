# CFP Summary

- Requester: Patrik Pfaffenbauer
- Amount: 10,000 DFI
- Receiving address: dVTLp4iqkp7P3fDf2PqtDKap21hGQaLMEa
- Purpose: Development of defichain notification service API + UI



------

## Original proposal

What is this defichain notification service?

With this service you can create notification for different type of action happening on the defichain.

For now I have implemented:

* Coinbase
  * A masternode with a give Public Key has minted a new block 
* UTXO
  * A UTXO transaction occured from or to a specific address

Notification gateways:

* Telegram Group (via bot-id and group-id)
* Mail (must be verified first)

The next steps:

- SMS gateway
- Push message
- More notification types
  - Price increase/decrease with a specific threshold
- Maybe implement also for Bitcoin?

I let the community decide which kind of notifications are useful and wanted. 



How does it work?

You can create a notification via the UI on my side or use the api (documentation about that will be published soon). The notification information will be saved in a database, and checked frequently (for now only 10mins). If the specific notification type occured, the message will be published to the given gateway.



Work together with other community projects eg. Smart DeFi Wallet + DeFiChain Masternode Monitor. 