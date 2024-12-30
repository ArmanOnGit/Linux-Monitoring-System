#!/bin/bash

# Get the free CPU percentage using mpstat
cpuFree=$(mpstat | awk 'NR==4 {print $12}')
cpuUsed=$(echo "100 - $cpuFree" | bc)        

# Display general CPU usage
echo "CPU usage: $cpuUsed %"
