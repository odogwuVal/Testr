#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
killall dotnet || echo "Process was not running."
