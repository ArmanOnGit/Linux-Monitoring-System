#!/bin/bash

# To find the total memory space
totalSwap=$(free |awk 'NR==3 {print $2}')

# To find the using space of memory
usedSwap=$(free |awk 'NR==3 {print $3}')


# Calculate the percentage with that precise data
Per=$(($usedSwap*100/$totalSwap))


#----------
# Final Result
echo "$usedSwap of $totalSwap - $Per%"