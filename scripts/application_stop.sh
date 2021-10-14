#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
 APP_ID=dotnet

if [ -n "${APP_ID}" ]; then
    echo "Stopping instance $APP_ID"
fi
