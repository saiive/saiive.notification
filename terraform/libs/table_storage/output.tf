output "storage" {
    value = azurerm_storage_account.data_storage.name
}

output "subscription_table" {
    value = azurerm_storage_table.table.name
}

output "storage_connection_string" {
    value = azurerm_storage_account.data_storage.primary_connection_string
}