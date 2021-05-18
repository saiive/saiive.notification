
module "service_bus" {
  source = "./libs/servicebus"
  

  prefix = var.prefix
  location = var.location
  environment = var.environment
  environment_tag = var.environment_tag

  resource_group = azurerm_resource_group.rg.name
}


module "function_app" {
  source = "./libs/function_app"

  prefix = "${var.environment}-${var.prefix}-alert"
  location = var.location
  
  environment = var.environment
  environment_tag = var.environment_tag
  resource_group = azurerm_resource_group.rg.name
  
  dns_name = "notification"
  dns_zone = var.dns_zone
  dns_zone_resource_group = var.dns_zone_resource_group

  function_app_file = "function.zip"
  app_version = var.app_version

  connection_strings = [
    {
      name  = "MessageTopic",
      type  = "Custom",
      value = module.service_bus.connection
    },
    {
      name  = "Subscriptions",
      type  = "Custom",
      value = module.table_storage_subscriptions.storage_connection_string
    }
  ]

  variables = {
    "SubscriptionsTable"    = module.table_storage_subscriptions.table
  }
}

module "function_app_messanger" {
  source = "./libs/function_app"

  prefix = "${var.environment}-${var.prefix}-messenger"
  location = var.location
  
  environment = var.environment
  environment_tag = var.environment_tag
  resource_group = azurerm_resource_group.rg.name
  
  dns_name = "notification-messenger"
  dns_zone = var.dns_zone
  dns_zone_resource_group = var.dns_zone_resource_group

  function_app_file = "function-messenger.zip"
  app_version = var.app_version

  connection_strings = [
    {
      name  = "MessageTopic",
      type  = "Custom",
      value = module.service_bus.connection
    },
    {
      name  = "Subscriptions",
      type  = "Custom",
      value = module.table_storage_subscriptions.storage_connection_string
    }
  ]

  variables = {
    "SubscriptionsTable"    = module.table_storage_subscriptions.table,
    "SendGridApiKey"        = data.azurerm_key_vault_secret.send_grid_key.value,
    "SenderMail"            = var.sender_mail
  }
}
