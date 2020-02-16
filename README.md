# FsTemplate
Template for F# project, distributed under [MIT License](/LICENSE)

## FsTemplate Usage
1. Click the above [**Use this Template**] button in GitHub website.

2. **Clone** your project
    ```shell
    $ git clone <URL>
    $ cd <ProjectName>
    ```
3. **Setup** Template
    ```shell
    $ dotnet tool restore
    $ dotnet fake build -t Setup # update tools and dependencies, remove sample projects
    ```

4. Change **CI Badges** in **[README.md](/README.md)**
    - Replace `wraikny/FsTemplate` to `<OWNER>/<REPO>`
    - Set your own AppVeyor badge ID
    - **If you don't use a CI service, comment out it from the below table**.
5. Create Your project: **[Create Project](#Create-Project)**
6. Remove this **[FsTemplate Usage](#FsTemplate-Usage)** from here
7.
    ```shell
    $ git commit --amend # as initial commit
    ```


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

## CLI

### Restoring after Clone
```shell
$ dotnet tool restore
```

### Build
```shell
$ dotnet fake build # Build all projects as Release
$ # or
$ dotnet build --project src/SampleApp [-c {Debug|Release}]
```

### Run
```shell
$ dotnet run --project src/SampleApp [-c {Debug|Release}]
```

### Tests
```shell
$ dotnet fake build -t Test
$ #or
$ dotnet run --project tests/SampleTest
```

## References
### [Paket](https://fsprojects.github.io/Paket/index.html)  
Each project requires `paket.references` file.

After updating [paket.dependencies](/paket.dependencies):
```shell
$ dotnet paket install
```

To Update Versions of Libraries,
```shell
$ dotnet paket update
```

### [FAKE](https://fake.build/)  
Scripting at [build.fsx](/build.fsx).  

```shell
$ dotnet fake build -t Clean # Run "Clean" Target
$ dotnet fake build # Run Default Taret
```

### Create Project
```shell
$ # Application
$ dotnet new console -lang=f# -o src/SampleApp
$ echo 'FSharp.Core' > src/SampleApp/paket.references
$ paket install

$ # Library
$ dotnet new classlib -lang=f# -o src/SampleLib
$ echo 'FSharp.Core' > src/SampleLib/paket.references
$ paket install
```

### Create Test Project
```shell
$ dotnet new console -lang=f# -o tests/SampleTest
$ echo -e 'FSharp.Core\nExpecto\nExpecto.FsCheck' > tests/SampleTest/paket.references

$ paket install # Add reference of Paket to .fsproj file
```
and then, Add **Project Name** to [build.fsx](/build.fsx).

### Create Solution
```shell
$ dotnet new sln
$ dotnet sln add src/SampleApp
$ dotnet sln add src/SampleLib
```

### Update Tool
```shell
$ dotnet fake build -t Tool
```
and then, commit [.config/dotnet-tools.json](/.config/dotnet-tools.json).

## Link
- [Paket（.NETのパッケージマネージャー）とFAKE（F#のMake）について - anti scroll](https://tategakibunko.hatenablog.com/entry/2019/07/09/123655)
- [.NET Core 3.0 の新機能 #ローカルツール - Microsoft Docs](https://docs.microsoft.com/ja-jp/dotnet/core/whats-new/dotnet-core-3-0#local-tools)
