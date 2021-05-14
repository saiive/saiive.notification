resource "azurerm_storage_table_entity" "subscription" {
  storage_account_name = var.storage
  table_name           = var.table

  partition_key = var.partition_key
  row_key       = var.row_key

  entity = var.entity_values
}