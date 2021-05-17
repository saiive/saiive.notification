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

  partition_key = "Coinbase_Min_1"
  row_key = "eab678e1-a4b6-4182-9c1e-6771e32772a7"

  entity_values = {
    AlertType                     = "Coinbase",
    Interval                      = "Min_1",
    PublicKey                     = "8e6cx8JGZ5cjEkYiWHrFV6C7VKJHuxxw3x",
    Name                          = "Masternode_1",
    NotificationConnectionString  = "type=telegram;botId=1708763613:AAEoW1rZNI-M-0jkmSArdLB7u3ZhIRCQUpA;channelId=-1001329326135"
  }
}

module "config_storage_subscriptions" {
  source = "./libs/table_storage"

  name = "config"
  storage_account = azurerm_storage_account.table_storage.name
  storage_account_connection_string = azurerm_storage_account.table_storage.primary_connection_string

  prefix = var.prefix
  location = var.location
  environment = var.environment

  resource_group = azurerm_resource_group.rg.name
}


module "table_entry_config_block_height_1min" {
  source = "./libs/table_storage_entry" 

  storage = module.config_storage_subscriptions.storage
  table = module.config_storage_subscriptions.table
  partition_key = "config"
  row_key = "last_height_1min"

  entity_values = {
    Value = 0
  }
}
module "table_entry_config_block_height_5min" {
  source = "./libs/table_storage_entry" 

  storage = module.config_storage_subscriptions.storage
  table = module.config_storage_subscriptions.table
  partition_key = "config"
  row_key = "last_height_5min"

  entity_values = {
    Value = 0
  }
}
module "table_entry_config_block_height_10min" {
  source = "./libs/table_storage_entry" 

  storage = module.config_storage_subscriptions.storage
  table = module.config_storage_subscriptions.table
  partition_key = "config"
  row_key = "last_height_10min"

  entity_values = {
    Value = 0
  }
}