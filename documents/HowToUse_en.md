# How To Use

## Use
1. clone then change remote
    ```shell
    $ git clone git@github.com:wraikny/FsTemplate.git
    $ git remote rm origin
    $ git remote add <your repogitory>
    ```
2. change url of [CI Badge in README.md](/README.md#L1)
3. Following [CreateNewProject](##CreateNewProject), create new project.

## Requirement
.NET Core SDK  
https://dotnet.microsoft.com/download

```shell
$ dotnet --version
3.0.100
```

macOS/Linux  
[Mono Framework](https://www.mono-project.com/download/stable/)  

Git Bash is good choice in Windows Environment.

## In first clone
```shell
$ ./paket.sh restore
```

## Build
```shell
$ ./fake.sh build
```

## Run
```
dotnet run --project src/SampleApp
```

## Package Manager
Using [Paket](https://fsprojects.github.io/Paket/index.html).  
Write dependencies in [paket.dependencies](paket.dependencies).  
If you updated it, execute
```shell
$ ./paket.sh install
```

In each project, write [paket.references](src/SampleApp/paket.references).
By the way, [paket.exe](.paket/paket.exe) is Magic Mode.

## Build script
Using [FAKE](https://fake.build/).  
Script in [build.fsx](build.fsx).
Set Target as
```shell
$ ./fake.sh -t "Clean"
```

## CreateNewProject
```shell
$ dotnet new console -lang=F# -o src/SampleApp # Library: not consle but classlib
$ echo 'FSharp.Core' > src/SampleApp
```

Add bellow to `*.fsproj`, with reference to [SampleApp.fsproj](src/SampleApp.fsproj),
```xml
<Import Project="..\..\.paket\Paket.Restore.targets" />
```