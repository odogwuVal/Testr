#!/bin/bash

echo "stopping Testr.API application"
cd /home/ubuntu/Testr.API
#DOTNET="pgrep dotnet"
  sudo pkill -9 Testr.API
