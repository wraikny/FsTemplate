# FsTemplate
Template for F# project, distributed under [MIT License](/LICENSE)

## Usage
1. Click the above [**Use this Template**] button.
2. **Clone** your regository
    ```shell
    $ git clone git@github.com:<OWNER>/<REPOSITORY>.git
    ```

3. Change **CI Badge** in **[README.md](/README.md)**
    - Replace `wraikny/FsTemplate` to `<OWNER>/<REPOSITORY>`
    - Set your own AppVeyor badge ID
    - **If you don't use a CI service, comment out it from the below table**.


4. Create project: **[Create Project](#Create-Project)**

## CI Status
|||
:---|:---
|Github Actions|[![](https://github.com/wraikny/FsTemplate/workflows/CI/badge.svg)](https://github.com/wraikny/FsTemplate/actions?workflow=CI)|
|Travis CI|[![](https://travis-ci.org/wraikny/FsTemplate.svg?branch=master)](https://travis-ci.org/wraikny/FsTemplate)|
|AppVeyor|[![](https://ci.appveyor.com/api/projects/status/5vtyb8v9twdpteb6?svg=true)](https://ci.appveyor.com/project/wraikny/FsTemplate)|

<!---
comment out in Markdown.
--->

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
Each project needs: [paket.references](/src/SampleApp/paket.references) file.

After updating [paket.dependencies](/paket.dependencies):
```shell
$ dotnet paket install
```

## [FAKE](https://fake.build/)  
Scripting at [build.fsx](/build.fsx).  

```shell
$ dotnet fake build -t Clean # Run "Clean" Target
$ dotnet fake build # Run Default Taret
```

## Create Project
```shell
$ dotnet new console -lang=f# -o src/SampleApp # Application
$ echo 'FSharp.Core' > src/SampleApp/paket.references

$ dotnet new classlib -lang=f# -o src/SampleLib # Library
$ echo 'FSharp.Core' > src/SampleLib/paket.references

$ paket install # Add reference of Paket to .fsproj file
```

## Create Test Project
```shell
$ dotnet new console -lang=f# -o tests/SampleTest
$ echo -e 'FSharp.Core\nExpecto\nExpecto.FsCheck' > tests/SampleTest/paket.references

$ paket install # Add reference of Paket to .fsproj file
```
and then, Add **Project Name** to [build.fsx](/build.fsx).

## Solution
```shell
$ dotnet new sln # Create Solution File
$ dotnet sln add src/SampleApp
$ dotnet sln add src/SampleLib
```

## Tool Update
```shell
$ dotnet tool update fake-cli
$ dotnet tool update paket
```
and then, commit [.config/dotnet-tools.json](/.config/dotnet-tools.json).

## Link
- [Paket（.NETのパッケージマネージャー）とFAKE（F#のMake）について - anti scroll](https://tategakibunko.hatenablog.com/entry/2019/07/09/123655)
- [.NET Core 3.0 の新機能 #ローカルツール - Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/core/whats-new/dotnet-core-3-0#local-tools)
