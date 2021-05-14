#!/bin/bash

# rm -rf .terraform/terraform.tfstate
# rm -rf .terraform/environment


terraform init -backend-config=backends/$1.tf 

terraform workspace new $2 2>/dev/null

terraform workspace select $2
# terraform plan -var-file=99-$2.tfvars -out=$2-plan.out

terraform apply -var-file=99-$1.tfvars