module SampleTest

open Expecto

[<Tests>]
let tests =
  test "simple test" {
    let subject = "Hello World"
    Expect.equal subject "Hello World" "The strings should equal"
  }

// [<Tests>]
let failTest =
  test "not tested" {
    Expect.equal 1 2 "fail"
  }

let config = { FsCheckConfig.defaultConfig with maxTest = 200 }

[<Tests>]
let properties =
  testList "FsCheck" [
    testProperty "add" <| fun a b ->
      a + b = b + a

    testProperty "reverve list" <|
      fun (xs: list<int>) -> List.rev (List.rev xs) = xs

    testPropertyWithConfig config "distribution law" <|
      fun a b c ->
        a * (b + c) = a * b + a * c
  ]

[<EntryPoint>]
let main argv =
    Tests.runTestsInAssembly defaultConfig argv