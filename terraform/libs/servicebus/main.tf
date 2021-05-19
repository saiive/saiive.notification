resource "azurerm_servicebus_namespace" "servicebus" {
  name                  = "${var.environment}-${var.prefix}-bus"
  resource_group_name   = var.resource_group
  location              = var.location
  sku                   = "Standard"

  tags = {
    Environment = var.environment_tag
  }
}

resource "azurerm_servicebus_topic" "topic" {
  name                  = "message"
  resource_group_name   = var.resource_group
  namespace_name        = azurerm_servicebus_namespace.servicebus.name

  enable_partitioning = true
}

module "notification_filter" {
    source = "../service_bus_subscription"

    name = "notification"
    resource_group = var.resource_group
    servicebus = azurerm_servicebus_namespace.servicebus.name
    topic = azurerm_servicebus_topic.topic.name

    to_filter = "notification"
}

module "added_filter" {
    source = "../service_bus_subscription"

    name = "added"
    resource_group = var.resource_group
    servicebus = azurerm_servicebus_namespace.servicebus.name
    topic = azurerm_servicebus_topic.topic.name

    to_filter = "added"
}
module "activated_filter" {
    source = "../service_bus_subscription"

    name = "activated"
    resource_group = var.resource_group
    servicebus = azurerm_servicebus_namespace.servicebus.name
    topic = azurerm_servicebus_topic.topic.name

    to_filter = "activated"
}
module "deactivated_filter" {
    source = "../service_bus_subscription"

    name = "deactivated"
    resource_group = var.resource_group
    servicebus = azurerm_servicebus_namespace.servicebus.name
    topic = azurerm_servicebus_topic.topic.name

    to_filter = "deactivated"
}