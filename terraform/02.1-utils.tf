data "azurerm_client_config" "current" {}


resource "azurerm_key_vault" "keyvault" {
  name                        = "${var.environment}-${var.prefix}"
  location                    = var.location
  resource_group_name         = azurerm_resource_group.rg.name
  enabled_for_disk_encryption = true
  soft_delete_retention_days  = 7
  purge_protection_enabled    = false
  tenant_id                   = data.azurerm_client_config.current.tenant_id
  sku_name = "standard"
 
  access_policy {
    tenant_id = data.azurerm_client_config.current.tenant_id
    object_id = data.azurerm_client_config.current.object_id

    key_permissions = [
      "create",
      "get",
    ]

    secret_permissions = [
      "set",
      "get",
      "delete",
      "purge",
      "recover"
    ]
  }
}

resource "azurerm_key_vault_secret" "send_grid_key" {
  name         = "sendgridkey"
  value        = "TODO"
  key_vault_id = azurerm_key_vault.keyvault.id

  lifecycle {
    ignore_changes = [
      value
    ]
  }
}
data "azurerm_key_vault_secret" "send_grid_key" {
  name         = "sendgridkey"
  key_vault_id = azurerm_key_vault.keyvault.id
}
