resource "azurerm_servicebus_namespace" "servicebus" {
  name                  = "${var.environment}-${var.prefix}-servicebus"
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

resource "azurerm_servicebus_subscription" "telgram" {
  name                  = "telgram"
  resource_group_name   = var.resource_group
  namespace_name        = azurerm_servicebus_namespace.servicebus.name
  topic_name            = azurerm_servicebus_topic.topic.name
  max_delivery_count    = 5
}


resource "azurerm_servicebus_subscription_rule" "subscription_rule_tg" {
  name                = "${var.environment}-${var.prefix}-rule_tg"
  resource_group_name   = var.resource_group
  namespace_name        = azurerm_servicebus_namespace.servicebus.name
  topic_name            = azurerm_servicebus_topic.topic.name

  subscription_name   = azurerm_servicebus_subscription.telgram.name
  filter_type         = "CorrelationFilter"

  correlation_filter {
    to = "telegram"
  }
}

resource "azurerm_servicebus_subscription" "mail" {
  name                  = "mail"
  resource_group_name   = var.resource_group
  namespace_name        = azurerm_servicebus_namespace.servicebus.name
  topic_name            = azurerm_servicebus_topic.topic.name
  max_delivery_count    = 5
}


resource "azurerm_servicebus_subscription_rule" "subscription_rule_mail" {
  name                = "${var.environment}-${var.prefix}-rule_mail"
  resource_group_name   = var.resource_group
  namespace_name        = azurerm_servicebus_namespace.servicebus.name
  topic_name            = azurerm_servicebus_topic.topic.name

  subscription_name   = azurerm_servicebus_subscription.telgram.name
  filter_type         = "CorrelationFilter"

  correlation_filter {
    to = "mail"
  }
}