#!/usr/bin/env bash
cd `dirname $0`

if test "$OS" = "Windows_NT"
then
    .paket/paket.exe "$@"
else
    mono .paket/paket.exe "$@"
fi