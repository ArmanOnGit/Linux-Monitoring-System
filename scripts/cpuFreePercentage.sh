#!/bin/bash
output=$(mpstat |awk 'NR==4 {print $12}')
echo "Free percentage : $output %"
