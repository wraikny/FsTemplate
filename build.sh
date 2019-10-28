#!/bin/bash

if test "$OS" = "Windows_NT"
then
    .paket/paket.exe restore
else
    mono .paket/paket.exe restore
fi

./fake.sh run build.fsx $@
