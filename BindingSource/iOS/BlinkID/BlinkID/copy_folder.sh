#!/bin/bash

if [ "$#" -ne 2 ]; then
  echo "Usage: $0 SRC_POS DST_POS"
  exit 1
fi

SRC_POS=$1
DST_POS=$2

echo "Copying folder from $SRC_POS to $DST_POS"
echo rsync -a --delete "$SRC_POS" "$DST_POS"
rsync -a --delete "$SRC_POS" "$DST_POS"