#!/bin/bash

mpstat |awk 'NR==4 {print $13}'

