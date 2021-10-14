#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
echo " Enter the process name:"
if pgrep dotnet
then
pkill dotnet
else
echo " dotnet is not running/stopped "
fi
