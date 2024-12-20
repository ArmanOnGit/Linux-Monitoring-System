#!/bin/bash

# To find the total memory space
totalMem_H=$(free -h |awk 'NR==2 {print $2}')

# Changing the systemic result to human readable
if [[ $totalMem_H == "7Gi" ]]; then
    totalMem_H="16GB"

elif [[ $totalMem_H == "15Gi" ]]; then
    totalMem_H="16GB"

elif [[ $totalMem_H == "31Gi" ]]; then
    totalMem_H="32GB"

elif [[ $totalMem_H == "63Gi" ]]; then
    totalMem_H="64GB"
fi

# To find the using space of memory
usedMem_H=$(free -h |awk 'NR==2 {print $3}'| sed 's/i/B/g')

#------------------
#Calculate the percentage with precise data

totalMem=$(free|awk 'NR==2 {print $2}')
usedMem=$(free |awk 'NR==2 {print $3}'| sed 's/i/B/g')

# Calculate the percentage with that precise data
Per=$(($usedMem*100/$totalMem))


#----------
# Final Result
echo "Memory usage: $usedMem_H of $totalMem_H - $Per%"