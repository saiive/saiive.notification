
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

  prefix = "${var.environment}-${var.prefix}"
  location = var.location
  
  environment_tag = var.environment_tag
  
  resource_group = azurerm_resource_group.rg.name

  function_app_file = "function.zip"
  app_version = var.app_version
}

module "function_app_messanger" {
  source = "./libs/function_app"

  prefix = "${var.environment}-${var.prefix}"
  location = var.location
  
  environment_tag = var.environment_tag
  
  resource_group = azurerm_resource_group.rg.name

  function_app_file = "function_messanger.zip"
  app_version = var.app_version
}
