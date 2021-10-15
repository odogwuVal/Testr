#!/bin/bash

 cd /root/Testr
 export ASPNETCORE_URLS="http://*:5000"
 dotnet ef database update -c AppDbContext -s Testr.API/Testr.API.csproj -p Testr.Infrastructure/Testr.Infrastructure.csproj
 dotnet publish -c Release -r ubuntu.16.04-x64 -o /var/www/Testr/
 cd /var/www/Testr
 nohup dotnet Testr.API.dll > /dev/null 2>&1&
