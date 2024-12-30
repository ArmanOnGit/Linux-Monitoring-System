#!/bin/bash
# We use "&" to split the output on the site

echo "System Date:"
date | awk '{print $3 " " $2 " " $6}'

echo "&"

echo "Current System Time:"
date | awk '{print $4 " "}'

echo "&"

echo -e "\nTimezone:"
cat /etc/timezone