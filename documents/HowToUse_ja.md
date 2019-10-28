# How To Use

## 使う
1. cloneしてリモートを変更
    ```shell
    $ git clone git@github.com:wraikny/FsTemplate.git
    $ git remote rm origin
    $ git remote add <自分のリポジトリ>
    ```
2. [READMD.mdのCIバッジ](/README.md#L1)のurlを変更する。
3. 後述の[新規ブロジェクト作成](##新規プロジェクト作成)に従い、プロジェクトを作成する。

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

## ビルド
```shell
$ ./fake.sh build
```

## 実行
```
dotnet run --project src/SampleApp
```

## パッケージ管理
[Paket](https://fsprojects.github.io/Paket/index.html) を使用する。  
[paket.dependencies](paket.dependencies) に依存関係を記述する。  
更新したら
```shell
$ ./paket.sh install
```
を実行する。

プロジェクトごとに [paket.references](src/SampleApp/paket.references) を記述する。
ちなみに、[paket.exe](.paket/paket.exe)はMagic Modeです。

## ビルドスクリプト
[FAKE](https://fake.build/) を使用する。  
[build.fsx](build.fsx) に処理を記述する。
```shell
$ ./fake.sh -t "Clean"
```
でTargetを指定する。

## 新規プロジェクト作成
```shell
$ dotnet new console -lang=F# -o src/SampleApp # ライブラリならconsoleではなくclasslibを指定する
$ echo 'FSharp.Core' > src/SampleApp
```

[SampleApp.fsproj](src/SampleApp.fsproj)を参考に、以下を `*.fsproj` に追加する。
```xml
<Import Project="..\..\.paket\Paket.Restore.targets" />
```


## 参考
- [Paket（.NETのパッケージマネージャー）とFAKE（F#のMake）について - anti scroll](https://tategakibunko.hatenablog.com/entry/2019/07/09/123655)
