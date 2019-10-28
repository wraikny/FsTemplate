[![Github Actions CI Status](https://github.com/wraikny/FsTemplate/workflows/CI/badge.svg)](https://github.com/wraikny/FsTemplate/actions?workflow=CI)
# FsTemplate
Template for F# project

## Use
1. **Clone** and change **remote repogitory**
    ```shell
    $ git clone git@github.com:wraikny/FsTemplate.git
    $ git remote rm origin
    $ git remote add origin <your repogitory>
    ```

2. Change **CI Badge** in **[README.md](/README.md)**
   ```md
   - badge: https://github.com/<OWNER>/<REPOSITORY>/workflows/CI/badge.svg
   - link: https://github.com/<OWNER>/<REPOSITORY>/actions?workflow=CI
   ```

3. Create project: **[Create Project](#Create-Project)**

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
$ dotnet run --project src/SampleApp
```

## Tests
```shell
$ dotnet fake build -t Test
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
