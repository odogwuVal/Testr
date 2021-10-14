#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
if pgrep dotnet; then pkill dotnet; fi
