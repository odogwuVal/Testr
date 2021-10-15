#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
#DOTNET="pgrep dotnet"
  sudo pkill -9 dotnet
