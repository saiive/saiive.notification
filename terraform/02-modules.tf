
module "service_bus" {
  source = "./libs/servicebus"
  

  prefix = var.prefix
  location = var.location
  environment = var.environment
  environment_tag = var.environment_tag

  resource_group = azurerm_resource_group.rg.name
}

module "table_storage_new_coinbase_tx" {
  source = "./libs/table_storage"

  name = "coinbasetx"

  prefix = var.prefix
  location = var.location
  environment = var.environment

  resource_group = azurerm_resource_group.rg.name
}
module "table_storage_new_utxo_tx" {
  source = "./libs/table_storage"

  name = "utxotx"

  prefix = var.prefix
  location = var.location
  environment = var.environment

  resource_group = azurerm_resource_group.rg.name
}

module "function_app" {
  source = "./libs/function_app"

  prefix = "${var.environment}-${var.prefix}-alert"
  location = var.location
  
  environment_tag = var.environment_tag
  
  resource_group = azurerm_resource_group.rg.name

  function_app_file = "function.zip"
  app_version = var.app_version

  connection_strings = [
    {
      name  = "MessageTopic",
      type  = "Custom",
      value = module.service_bus.connection
    },
    {
      name  = "CoinbaseTxConnection",
      type  = "Custom",
      value = module.table_storage_new_coinbase_tx.storage_connection_string
    },
    {
      name  = "UtxoTxConnection",
      type  = "Custom",
      value = module.table_storage_new_utxo_tx.storage_connection_string
    }
  ]

  variables = {
    "CoinbaseTxTable"    = module.table_storage_new_coinbase_tx.subscription_table,
    "UtxoTxConnection"   = module.table_storage_new_utxo_tx.subscription_table
  }
}

module "function_app_messanger" {
  source = "./libs/function_app"

  prefix = "${var.environment}-${var.prefix}-messenger"
  location = var.location
  
  environment_tag = var.environment_tag
  
  resource_group = azurerm_resource_group.rg.name

  function_app_file = "function-messenger.zip"
  app_version = var.app_version

  connection_strings = [
    {
      name  = "MessageTopic",
      type  = "Custom",
      value = module.service_bus.connection
    },
    {
      name  = "CoinbaseTxConnection",
      type  = "Custom",
      value = module.table_storage_new_coinbase_tx.storage_connection_string
    },
    {
      name  = "UtxoTxConnection",
      type  = "Custom",
      value = module.table_storage_new_utxo_tx.storage_connection_string
    }
  ]

  variables = {
    "CoinbaseTxTable"    = module.table_storage_new_coinbase_tx.subscription_table,
    "UtxoTxConnection"   = module.table_storage_new_utxo_tx.subscription_table
  }
}
