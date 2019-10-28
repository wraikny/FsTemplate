# FsTemplate

## 必須
.NET Core SDK  
https://dotnet.microsoft.com/download

```shell
$ dotnet --version
3.0.100
```

macOS/Linuxの場合  
[Mono Framework](https://www.mono-project.com/download/stable/)  

Windowsの人はGit Bashとか使うといいと思います。

## 初回Clone時
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
[Paket](https://fsprojects.github.io/Paket/index.html) を使用する。  
[paket.dependencies](paket.dependencies) に依存関係を記述する。  
更新したら
```shell
$ ./paket.sh install
```
を実行する。

プロジェクトごとに [paket.references](src/SampleApp/paket.references) を記述する。

## Build Script
[FAKE](https://fake.build/) を使用する。
[build.fsx](build.fsx) に処理を記述する。
```shell
$ ./fake.sh -t "Clean"
```
でTargetを指定する
