#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
#DOTNET="pgrep dotnet"
pgrep dotnet
t=$((echo $?) 2>&1)
if [ "$t" = "0" ]; then
  sudo pkill -9 dotnet
else
  exit
fi

