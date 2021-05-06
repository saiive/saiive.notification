

# Create a resource group
resource "azurerm_resource_group" "rg" {
  name     = var.prefix
  location = "West Europe"

  tags = {
    Environment = var.environment
    Version = var.app_version
  }
}
