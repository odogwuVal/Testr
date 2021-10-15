#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
DOTNET="pgrep dotnet"
if [[ -n  $DOTNET ]]; then
      sudo pkill httpd
fi
