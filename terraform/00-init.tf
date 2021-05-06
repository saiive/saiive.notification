terraform {
  backend "azurerm" {
    key = "defi/saiive-alert.terraform.tfstate"
  }
}
terraform {
  required_version = ">= 0.13"
}

terraform {
  required_providers {
    uptimerobot = {
      source  = "louy/uptimerobot"
      version = "0.5.1"
    }

    azurerm = {
      source = "hashicorp/azurerm"
    }

    scaleway = {
      source = "scaleway/scaleway"
      version = "1.17.2"
    }

    local = {
      source = "hashicorp/local"
    }

    null = {
      source = "hashicorp/null"
    }

    template = {
      source = "hashicorp/template"
    }
  }
}

provider "http" {
  
}


# define the deployment location (az account list-locations --output table)
variable "location" {
    type = string
    default = "westeurope"
}

# define the prefixed name
variable "prefix" {
	description = "deployment prefix"
}

variable "environment_tag" {
}

variable "app_version" {
	
}

# define the path of the zipped function app
variable "functionapp" {
    type = string
    default = "./functionapp.zip"
}
