#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
DOTNET="pgrep dotnet"
pkill -9 dotnet
