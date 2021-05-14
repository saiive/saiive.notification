resource "azurerm_storage_account" "data_storage" {
  name                     = "${var.environment}ti2gotablestorage"
  resource_group_name      = var.resource_group
  location                 = var.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
    
  tags = {
      Environment = var.environment
  }
}

resource "azurerm_storage_table" "table" {
  name                 = "subscriptions"
  storage_account_name = azurerm_storage_account.data_storage.name
    
}