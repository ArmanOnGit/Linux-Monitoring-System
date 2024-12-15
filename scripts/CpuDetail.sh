#!/bin/bash
    
# Loop through all CPU cores to get their frequencies
i=0
for cpu in /sys/devices/system/cpu/cpu*/cpufreq/scaling_cur_freq; do
    # Get current frequency
    cpuFreq=$(cat $cpu)
    cpuFreqMHz=$((cpuFreq / 1000))  # Convert the frequency to MHz

    # Numbering
    coreNum=$i

    # Get max frequency for the same core
    maxFreq=$(cat /sys/devices/system/cpu/cpu$coreNum/cpufreq/cpuinfo_max_freq)
    maxFreqMHz=$((maxFreq / 1000))  # Convert the max frequency to MHz

    # Print the formatted output
    showingNum=$(($coreNum+1))
    echo "Core $showingNum : $cpuFreqMHz MHz of $maxFreqMHz MHz"

    if [[ $i -lt 11 ]]; then
        echo "-"
    fi

    # Add to i
    i=$(($i+1))
done
