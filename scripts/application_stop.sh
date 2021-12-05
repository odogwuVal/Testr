#!/bin/bash

echo "stopping Testr.API application now"
#DOTNET="pgrep dotnet"
pm2 stop all
pm2 delete all  
