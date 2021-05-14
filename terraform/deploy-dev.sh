#!/bin/bash

echo "Setting environment variables for Terraform"
export ARM_SUBSCRIPTION_ID=551ab192-148c-445b-ae4f-0d0107e6f5de
export ARM_CLIENT_ID=21eaab80-95bb-4093-90b7-826bd746c41a
export ARM_CLIENT_SECRET=K2D9cgWOz0mlZ.yy7cQB0f2fCWhbAnU~Ez
export ARM_TENANT_ID=64ebf03d-976e-40ae-802a-ee8722720bdb
export TF_LOG=


./deploy.sh dev dev
