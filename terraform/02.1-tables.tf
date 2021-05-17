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