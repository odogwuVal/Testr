#!/bin/bash

 cd /home/ubuntu/Testr.API
 pm2 start 'dotnet run  --urls "http://localhost:5000"' --name Testr
