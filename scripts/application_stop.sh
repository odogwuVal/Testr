#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
pkill -9 dotnet
