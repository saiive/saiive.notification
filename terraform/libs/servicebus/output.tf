output "connection" {
  value = azurerm_servicebus_namespace.servicebus.default_primary_connection_string 
}
output "name" {
  value = azurerm_servicebus_namespace.servicebus.name
}