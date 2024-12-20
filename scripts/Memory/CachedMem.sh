#!/bin/bash

# To find the Cached space
totalCached=$(free -h|awk 'NR==2 {print $6}' | sed 's/i/B/g')

echo $totalCached