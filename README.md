![](https://github.com/wraikny/FsTemplate/workflows/CI/badge.svg)
# FsTemplate
Template for F# project

## Use
1. clone and set your remote
    ```shell
    $ git clone git@github.com:wraikny/FsTemplate.git
    $ git remote rm origin
    $ git remote add origin <your repogitory>
    ```

2. Change CI badge URL in README.md
   ```md
   ![](https://github.com/<username>/<projectname>/workflows/CI/badge.svg)
   ```

3. Create new project, following to [Create New Project](##Create%sNew%sProject)

## Requirements
.NET Core SDK 3.0  
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

## [Paket](https://fsprojects.github.io/Paket/index.html)  
Each project: [src/SampleApp/paket.references](/src/SampleApp/paket.references).

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

## Create New Project
```shell
$ dotnet new console -lang=F# -o src/SampleApp # Application
$ dotnet new classlib -lang=F# -o src/SampleLib # Library
$ echo 'FSharp.Core' > src/SampleApp/paket.references
```
and then, Add
```xml
<Import Project="..\..\.paket\Paket.Restore.targets" />
```
to `*.fsproj`, like [SampleApp.fsproj](/src/SampleApp/SampleApp.fsproj).

## Link
- [Paket（.NETのパッケージマネージャー）とFAKE（F#のMake）について - anti scroll](https://tategakibunko.hatenablog.com/entry/2019/07/09/123655)
