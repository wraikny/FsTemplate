#!/usr/bin/env bash

./paket.sh restore
./fake.sh run build.fsx $@
