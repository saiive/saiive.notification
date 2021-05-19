

resource "azurerm_servicebus_subscription" "subscription" {
  name                  = var.name
  resource_group_name   = var.resource_group
  namespace_name        = var.servicebus
  topic_name            = var.topic
  max_delivery_count    = 5
}


resource "azurerm_servicebus_subscription_rule" "subscription_rule" {
  name                = "${var.name}-sub-rule"
  resource_group_name   = var.resource_group
  namespace_name        = var.servicebus
  topic_name            = var.topic

  subscription_name   = azurerm_servicebus_subscription.subscription.name
  filter_type         = "CorrelationFilter"

  correlation_filter {
    to = var.to_filter
  }
}