terraform {
  backend "azurerm" {
    key = "alert/saiive-alert.terraform.tfstate"
  }
}
terraform {
  required_version = ">= 0.13"
}

terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
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
provider "azurerm" {
  features {}
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

variable "environment" {
}

variable "environment_tag" {
}

variable "app_version" {
	default = "20210514.1"
}

variable "sender_mail" {

}