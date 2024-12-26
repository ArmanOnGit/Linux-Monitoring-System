#!/bin/bash

echo "System Uptime:"
uptime -p

echo "*"
echo -e "\nLast Reboot Time:"
who -b | awk '{print $3, $4}'
