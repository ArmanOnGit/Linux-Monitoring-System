#!/bin/bash
echo " "
echo " "
echo " "
echo "===================="
echo "General System Info"
echo "===================="

echo -e "\nHostname: $(hostname)"
echo "Kernel Version: $(uname -r)"
echo "System Architecture: $(uname -m)"

echo -e "\n==================="
echo "Date, Time & Timezone"
echo "==================="
echo "Current System Date and Time: $(date)"
echo "System Timezone: $(timedatectl | grep 'Time zone' | awk '{print $3, $4}')"

echo -e "\n====================="
echo "Uptime and Last Reboot"
echo "====================="
echo "System Uptime: $(uptime -p)"
echo "Last Reboot Time: $(who -b | awk '{print $3, $4}')"

echo -e "\n==================="
echo "Running Processes"
echo "==================="
echo "Number of Running Processes: $(ps -e --no-headers | wc -l)"

echo " "
echo " "
echo " "
