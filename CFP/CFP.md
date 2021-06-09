### Overview
1. Requester(s):  Patrik Pfaffenbauer, @p3root
2. Amount requested in DFI: 5000
3. Receiving address: dVTLp4iqkp7P3fDf2PqtDKap21hGQaLMEa
4. Reddit discussion thread: https://www.reddit.com/r/defiblockchain/comments/ngb3gv/defichain_notification_service/
5. Proposal fee (10 DFI) txid: [Insert txid of 10 DFI sent to the burn address]



## What is this defichain notification service?

With this service you can create notification for different type of action happening on the defichain and also for Bitcoin.

### Notification types

* Coinbase
  * A masternode with a given Public Key has minted a new block 
* UTXO
  * A UTXO transaction occurred from or to a specific address
* Whale (WIP)
  * A tx with a specific amount of DFI, EUR or USD (always calculated from the DFI amount) was commited to the blockchain
  * For this notification type we will also run and maintain a Twitter Account (https://twitter.com/DeFiWhaleAlert)
* PriceAlert
  * Absolut or percentage move of the DFI price (at the beginning we will use the Coingecko API to get the current price)

### Notification gateways:

* Telegram Group (via bot-id and group-id)
* Mail 
* Twitter (api key, api secret, consumer key, consumer secret)

All notification must be confirmed with a message (will be sent via a message, eg for email via email, Telegram via telegram message).

### The next steps:

- SMS gateway
- Push message
- More notification types

I let the community decide which kind of notifications are useful and wanted. 


### How does it work?

You can create a notification via the UI on my side or use the API (documentation about that will be published soon). 
The notification information will be saved in a database, and checked frequently (for now only 10mins). 
If the specific notification type occurred, the message will be published to the given gateway.


I also want to integrate that in the Smart DeFi Wallet. Also other services like DeFiChain Masternode Monitor or DeFiChain Income can implement the API. 

### Beta Test

Will start within the next couple weeks.


## How will the funds be spent?

Infrastructure + development costs. 
