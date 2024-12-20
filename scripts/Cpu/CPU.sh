#!/bin/bash

# Get the free CPU percentage using mpstat
cpuFree=$(mpstat | awk 'NR==4 {print $12}')  # Extract the free CPU percentage
cpuUsed=$(echo "100 - $cpuFree" | bc)        # Calculate the used CPU percentage

# Display general CPU usage
echo "CPU usage: $cpuUsed %"
