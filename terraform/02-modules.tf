
module "function_app" {
  source = "./libs/function_app"

  prefix = "${var.prefix}"
  location = var.location
  
  environment_tag = var.environment_tag
  
  resource_group = azurerm_resource_group.rg.name

  function_app_file = "function.zip"
  app_version = var.app_version
}
