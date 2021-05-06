#!/bin/bash

echo "Setting environment variables for Terraform"
export ARM_SUBSCRIPTION_ID=d2815c5b-7edd-438f-b643-91dc4c584417
export ARM_CLIENT_ID=4013c524-4205-47a9-8d27-6ae744247179
export ARM_CLIENT_SECRET=d4e82887-74f5-4031-8c51-25b9a53415e5
export ARM_TENANT_ID=d5b7e8c1-0ccf-479f-a5d4-1ac10e7dcbb6


rm -rf .terraform/terraform.tfstate
rm -rf .terraform/environment

terraform init -backend-config=backends/backend.tf
terraform apply -var-file=99-vars.tfvars -var="app_version=20200316.11" 