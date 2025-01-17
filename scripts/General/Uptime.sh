#!/bin/bash
# We use "&" to split the output on the site

echo "Number of Running Processes: "
ps -e --no-headers | wc -l

echo "&"

echo "System Uptime:"
uptime -p

echo "&"

echo -e "\nLast Reboot:"
who -b | awk '{print $3, $4}'
