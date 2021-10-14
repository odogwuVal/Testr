#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
echo " Enter the process name:"
pkill -9 -f dotnet || true
