#!/bin/bash

echo -e "\nSystem Timezone:"
timedatectl | grep "Time zone" | awk '{print $3, $4}'

echo "*"

echo "Current System Date and Time:"
date

