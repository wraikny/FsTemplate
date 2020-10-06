#r "paket:
source https://api.nuget.org/v3/index.json
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Target
nuget Fake.Core.ReleaseNotes
nuget Fake.DotNet.AssemblyInfoFile
nuget Fake.DotNet.Testing.Expecto"

#load ".fake/build.fsx/intellisense.fsx"
#r "netstandard"

open Fake.Core
open Fake.DotNet
open Fake.DotNet.Testing
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

let testProjects = [
  "SampleTest"
  // "NewTestProject"
  // (F# list is separated '\n' or ';', not ',')
]

let publishProjects = [
  "SampleApp", [ "win-x64"; "osx-x64"; "linux-x64" ]
]

Target.initEnvironment()

Target.create "Test" (fun _ ->
  [ for x in testProjects ->
      sprintf "tests/%s/bin/Release/**/%s.dll" x x
  ] |> function
  | [] ->
    printfn "There is no test project"
  | x::xs ->
    Seq.fold (++) (!! x) xs
    |> Expecto.run id
)

let dotnet cmd arg = DotNet.exec id cmd arg |> ignore

Target.create "Tool" (fun _ ->
  dotnet "tool" "update fake-cli"
)

Target.create "Setup" (fun _ ->
  Directory.delete "src/SampleApp"
  Directory.delete "tests/SampleTest"
)

Target.create "Clean" (fun _ ->
  !! "src/**/bin"
  ++ "src/**/obj"
  ++ "tests/**/bin"
  ++ "tests/**/obj"
  |> Shell.cleanDirs
)

Target.create "Build" (fun _ ->
  !! "src/**/*.*proj"
  ++ "tests/**/*.*proj"
  |> Seq.iter (DotNet.build id)
)

Target.create "Publish" (fun _ ->
  Shell.cleanDir "publish"

  publishProjects
  |> Seq.iter(fun (project, runtimes) ->
    runtimes
    |> Seq.iter(fun runtime ->
      let outputPath = sprintf "publish/%s.%s" project runtime

      sprintf "src/%s" project
      |> DotNet.publish (fun p ->
        { p with
            Runtime = Some runtime
            Configuration = DotNet.BuildConfiguration.Release
            SelfContained = Some true
            MSBuildParams = {
              p.MSBuildParams with
                Properties =
                  ("PublishSingleFile", "true")
                  :: ("PublishTrimmed", "true")
                  :: p.MSBuildParams.Properties
            }
            OutputPath = Some outputPath
        }
      )
    )
  )
)

Target.create "All" ignore

"Clean"
  ==> "Build"
  ==> "All"

"Tool"
  ==> "Setup"

Target.runOrDefault "All"
