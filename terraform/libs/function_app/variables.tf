# define the prefixed name
variable "prefix" {
	description = "deployment prefix"
}

variable "location" {
	
}

variable "resource_group" {
	
}
variable "environment" {
  
}
variable "environment_tag" {
  
}

variable "function_app_file" {

}

variable "app_version" {
	
}

variable "tier" {
	default = "Dynamic"
}

variable "size" {
	default = "Y1"
}


variable "variables" {
	type = map
	default = {}
}

variable "connection_strings" {
	type = list

	default = []
}

variable "dns_name" {
	
}
variable "dns_zone" {
  
}
variable "dns_zone_resource_group" {

}