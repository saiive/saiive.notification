output "storage" {
    value = var.storage_account
}

output "table" {
    value = azurerm_storage_table.table.name
}

output "storage_connection_string" {
    value = var.storage_account_connection_string
}
