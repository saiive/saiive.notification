resource "azurerm_storage_account" "table_storage" {
  name                     = "${var.environment}saiivetables"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
    
  tags = {
      Environment = var.environment
  }
}


module "table_storage_subscriptions" {
  source = "./libs/table_storage"

  name = "subscriptions"

  storage_account = azurerm_storage_account.table_storage.name
  storage_account_connection_string = azurerm_storage_account.table_storage.primary_connection_string

  prefix = var.prefix
  location = var.location
  environment = var.environment

  resource_group = azurerm_resource_group.rg.name
}


module "table_entry_sub1" {
  source = "./libs/table_storage_entry" 

  storage = module.table_storage_subscriptions.storage
  table = module.table_storage_subscriptions.table

  partition_key = "Coinbase_Min_10"
  row_key = "eab678e1-a4b6-4182-9c1e-6771e32772a7"

  entity_values = {
    AlertType                     = "Coinbase",
    Interval                      = "Min_10",
    PublicKey                     = "8e6cx8JGZ5cjEkYiWHrFV6C7VKJHuxxw3x",
    Name                          = "Masternode_1",
    NotificationConnectionString  = "type=telegram;botId=1708763613:AAEoW1rZNI-M-0jkmSArdLB7u3ZhIRCQUpA;channelId=-1001329326135",
    LastBlockHeight               = "0"
  }
}
module "table_entry_sub3" {
  source = "./libs/table_storage_entry" 

  storage = module.table_storage_subscriptions.storage
  table = module.table_storage_subscriptions.table

  partition_key = "Coinbase_Min_10"
  row_key = "fee50f1a-df50-405d-80f7-66363f29ed85"

  entity_values = {
    AlertType                     = "Coinbase",
    Interval                      = "Min_10",
    PublicKey                     = "8XVuitUvR9KVjmieuwKjXSLZaoCX4zeNJo",
    Name                          = "Masternode_3",
    NotificationConnectionString  = "type=telegram;botId=1708763613:AAEoW1rZNI-M-0jkmSArdLB7u3ZhIRCQUpA;channelId=-1001329326135"
    LastBlockHeight               = "0"
  }
}