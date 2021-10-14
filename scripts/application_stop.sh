#!/bin/bash

echo "stopping Testr.API application"
cd /var/www/Testr/
echo " Enter the process name:"
proc_name=dotnet
if pgrep $proc_name
then
echo " $proc_name running "
pkill $proc_name
echo "$proc_name  got killed"
else
echo " $proc_name is not running/stopped "
fi
