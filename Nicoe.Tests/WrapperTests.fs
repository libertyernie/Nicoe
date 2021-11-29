namespace Nicoe.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type WrapperTests () =
    [<TestMethod>]
    member __.TestPacking () =
        use o1 = new NintendontConfiguration ()
        let data = o1.Export()
        Assert.AreEqual (548, data.Length)

    [<TestMethod>]
    member __.TestDefaultEquality () =
        use o1 = new NintendontConfiguration ()
        use o2 = new NintendontConfiguration ()
        Assert.IsFalse (LanguagePrimitives.PhysicalEquality o1 o2)
        Assert.AreEqual (o1, o2)

    [<TestMethod>]
    member __.TestInequality () =
        use o1 = new NintendontConfiguration ()
        use o2 = new NintendontConfiguration ()
        o2.GameID <- "G4SE"
        Assert.AreNotEqual (o1, o2)

    [<TestMethod>]
    member __.TestGameIDUnderflow () =
        use o1 = new NintendontConfiguration ()
        o1.GameID <- "AAAA"
        o1.GameID <- "C"
        Assert.AreEqual ("C", o1.GameID)

    [<TestMethod>]
    member __.TestGameIDOverflow () =
        use o1 = new NintendontConfiguration ()
        o1.GameID <- "ABCDE"
        Assert.AreEqual ("ABCD", o1.GameID)

    [<TestMethod>]
    member __.TestGamePathOverflow () =
        use o1 = new NintendontConfiguration ()
        o1.GamePath <- Seq.replicate 300 'X' |> Seq.toArray |> String
        Assert.AreEqual (255, o1.GamePath.Length)

    [<TestMethod>]
    member __.TestCheatPathOverflow () =
        use o1 = new NintendontConfiguration ()
        o1.CheatPath <- Seq.replicate 300 'X' |> Seq.toArray |> String
        Assert.AreEqual (255, o1.CheatPath.Length)