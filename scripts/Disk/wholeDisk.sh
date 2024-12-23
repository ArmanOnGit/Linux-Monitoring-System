#!/bin/bash

echo " "
function nvmeDisks()
{
    diskPartitions=$(lsblk | grep disk | awk '{print $1}')
    for items in $diskPartitions; do
        i=1
        for item in $diskPartitions; do
            lsblk -o TYPE,NAME,SIZE | grep disk | head -n $i
            echo "*"
            lsblk -o NAME,TYPE,SIZE,MOUNTPOINT,FSAVAIL | grep $item | grep part | sed 's/part//g' | sed 's/ ^t^| ^t^`//g' | sed 's/ ^t^t ^t^`//g' | sed 's/`-/|-/g' | sed 's/\//|-\//'
            echo
            i+=1
        done
    done

}

nvmeDisks | sed 's/disk/Disk:  /' | sed 's/^\*$/*\nPartitions:\n/'