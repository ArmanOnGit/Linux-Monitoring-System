#!/bin/bash
# We use "&" to split the output on the site

echo "System Hostname:"
hostname

echo "&"

echo "OS Version: "
cat /etc/os-release | grep "PRETTY_NAME=" | sed 's/PRETTY_NAME=//g' | sed 's/"//g'

echo "&"

echo -e "\nKernel Version: "
uname -r
