#!/bin/bash
# Monitor real-time bandwidth usage

INTERFACES=$(ls /sys/class/net/)

echo ""

for item in $INTERFACES; do

    INTERFACE=${item}
    echo $INTERFACE
    RX_BEFORE=$(cat /sys/class/net/$INTERFACE/statistics/rx_bytes)
    TX_BEFORE=$(cat /sys/class/net/$INTERFACE/statistics/tx_bytes)
    sleep 1
    RX_AFTER=$(cat /sys/class/net/$INTERFACE/statistics/rx_bytes)
    TX_AFTER=$(cat /sys/class/net/$INTERFACE/statistics/tx_bytes)

    RX_RATE=$((($RX_AFTER - $RX_BEFORE) / 1024))  # KBps
    TX_RATE=$((($TX_AFTER - $TX_BEFORE) / 1024))  # KBps

    echo "Download: ${RX_RATE} KB/s | Upload: ${TX_RATE} KB/s"
    echo " "
done

