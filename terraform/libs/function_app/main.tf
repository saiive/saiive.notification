
resource "random_string" "storage_name" {
    length = 24
    upper = false
    lower = true
    number = true
    special = false
}

# storage for the function app
resource "azurerm_storage_account" "storage" {
    name = random_string.storage_name.result
    resource_group_name = var.resource_group
    location = var.location
    account_tier = "Standard"
    account_replication_type = "LRS"  
    
    tags = {
        Environment = var.environment_tag
    }
}


# storage container for the function app
resource "azurerm_storage_container" "deployments" {
    name = "function-releases"
    storage_account_name = azurerm_storage_account.storage.name
    container_access_type = "private"

}

# blob for the function app
resource "azurerm_storage_blob" "appcode" {
    name = "${var.function_app_file}.zip"
    storage_account_name = azurerm_storage_account.storage.name
    storage_container_name = azurerm_storage_container.deployments.name
    type = "Block"
    source = "${var.app_version}-${var.function_app_file}"
}


data "azurerm_storage_account_sas" "sas" {
    connection_string = azurerm_storage_account.storage.primary_connection_string
    https_only = true
    start = "2019-01-01"
    expiry = "2021-12-31"
	
    resource_types {
        object = true
        container = false
        service = false
    }
	
    services {
        blob = true
        queue = false
        table = false
        file = false
    }
	
    permissions {
        read = true
        write = false
        delete = false
        list = false
        add = false
        create = false
        update = false
        process = false
    }
}

resource "azurerm_app_service_plan" "asp" {
    name = "${var.prefix}-splan"
    resource_group_name = var.resource_group
    location = var.location
    kind = "functionapp"
	reserved = false
    sku {
        tier = var.tier
        size = var.size
    }
    
    tags = {
        Environment = var.environment_tag
    }
}

resource "azurerm_function_app" "functions" {
    name = "${var.prefix}-function"
    location = var.location
    resource_group_name = var.resource_group
    app_service_plan_id = azurerm_app_service_plan.asp.id
    storage_connection_string = azurerm_storage_account.storage.primary_connection_string
    version = "~3"

    app_settings = {
        https_only = true
        FUNCTIONS_WORKER_RUNTIME = "dotnet"
        OpenApi__Info__License__Name = "~10"
        OpenApi__Info__Title = "PoC APIM Azure Functions"
        OpenApi__Info__Version = "3.0.0"
        FUNCTION_APP_EDIT_MODE = "readonly"
        WEBSITE_ENABLE_SYNC_UPDATE_SITE = "false"
        HASH = "${base64encode(filesha256("${var.app_version}-${var.function_app_file}"))}"
        WEBSITE_RUN_FROM_PACKAGE = "https://${azurerm_storage_account.storage.name}.blob.core.windows.net/${azurerm_storage_container.deployments.name}/${azurerm_storage_blob.appcode.name}${data.azurerm_storage_account_sas.sas.sas}"
        WEBSITE_LOAD_USER_PROFILE = 1
    }

    
    tags = {
        Environment = var.environment_tag
        Version = var.app_version
    }
}
