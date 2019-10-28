# FsTemplate
Template for F# project, distributed under [MIT License](/LICENSE)

## Use
1. **Clone** and change **remote repogitory**
    ```shell
    $ git clone git@github.com:wraikny/FsTemplate.git
    $ git remote rm origin
    $ git remote add origin <your repogitory>
    ```

2. Replace **CI Badge** in **[README.md](/README.md)**
    ```md
    'wraikny/FsTemplate' to '<OWNER>/<REPOSITORY>'
    (AppVeyor badge uses unique project ID)
   ```

3. Create project: **[Create Project](#Create-Project)**

## CI
|||
---|---
|Github Actions|[![](https://github.com/wraikny/FsTemplate/workflows/CI/badge.svg)](https://github.com/wraikny/FsTemplate/actions?workflow=CI)|
|Travis CI|[![](https://travis-ci.org/wraikny/FsTemplate.svg?branch=master)](https://travis-ci.org/wraikny/FsTemplate)|
|AppVeyor|[![](https://ci.appveyor.com/api/projects/status/5vtyb8v9twdpteb6?svg=true)](https://ci.appveyor.com/project/wraikny/FsTemplate)|

## Requirements
.NET Core 3.0  
https://dotnet.microsoft.com/download  

```shell
$ dotnet --version
3.0.100
```

## Restoring after Clone
```shell
$ dotnet tool restore
$ dotnet paket restore
```

## Build
```shell
$ dotnet fake build
```

## Run
```shell
$ dotnet run --project src/SampleApp [-c {Debug|Release}]
```

## Tests
```shell
$ dotnet fake build -t Test
```
OR
```
$ dotnet run --project tests/SampleTest
```

## [Paket](https://fsprojects.github.io/Paket/index.html)  
Each project needs: [src/SampleApp/paket.references](/src/SampleApp/paket.references).

After updating [paket.dependencies](/paket.dependencies) :
```shell
$ dotnet paket install
```

## [FAKE](https://fake.build/)  
Scripting at [build.fsx](/build.fsx)  

```shell
$ dotnet fake build -t Clean # Run "Clean" Target
$ dotnet fake build # Run Default Taret
```

## Create Project
```shell
$ dotnet new console -lang=F# -o src/SampleApp # Application
$ echo 'FSharp.Core' > src/SampleApp/paket.references

$ dotnet new classlib -lang=F# -o src/SampleLib # Library
$ echo 'FSharp.Core' > src/SampleLib/paket.references

$ paket install # add reference to paket
```

## Create Test Project
```shell
$ dotnet new console -lang=F# -o tests/SampleTest
$ echo -e 'FSharp.Core\nExpecto\nExpecto.FsCheck' > tests/SampleTest/paket.references

$ paket install # add reference to paket
```
and then, Add project name to [build.fsx](/build.fsx).

## Link
- [Paket（.NETのパッケージマネージャー）とFAKE（F#のMake）について - anti scroll](https://tategakibunko.hatenablog.com/entry/2019/07/09/123655)
- [.NET Core 3.0 の新機能 #ローカルツール - Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/core/whats-new/dotnet-core-3-0#local-tools)
