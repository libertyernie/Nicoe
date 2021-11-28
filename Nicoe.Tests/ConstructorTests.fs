namespace Nicoe.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type ConstructorTests () =
    let ToByteList (strings: string seq) = [
        for str in strings do
            let mutable i = 0
            while i + 2 <= str.Length do
                yield Byte.Parse (str.Substring (i, 2), Globalization.NumberStyles.HexNumber)
                i <- i + 2
    ]

    let ExpectedDefault = ToByteList [
        "01070CF6" // Magicbytes
        "0000000A" // Version (10)
        "00000000" // Config
        "00000000" // VideoMode
        "FFFFFFFF" // Language (Auto)
        for _ in [0..255] do "00" // GamePath (256 bytes)
        for _ in [0..255] do "00" // CheatPath (256 bytes)
        "00000004" // MaxPads
        "00000000" // GameID
        "02" // MemCardBlocks
        "00" // VideoScale
        "00" // VideoOffset
        "00" // NetworkProfile
        "00000000" // WiiUGamepadSlot
    ]

    let French = ToByteList [
        "01070CF6"
        "0000000A"
        "00000000"
        "00000000"
        "00000002"
        for _ in [0..255] do "00"
        for _ in [0..255] do "00"
        "00000004"
        "00000000"
        "02"
        "00"
        "00"
        "00"
        "00000000"
    ]

    [<TestMethod>]
    member this.TestDefaultConstructor () =
        let o1 = new NintendontConfiguration ()
        let data = o1.Export ()
        Assert.AreEqual (548, data.Length)
        Assert.AreEqual (ExpectedDefault, List.ofArray data)

    [<TestMethod>]
    member this.TestParseSuccess () =
        let o1 = new NintendontConfiguration ()
        let o2 = new NintendontConfiguration ()

        Assert.AreEqual(o1, o2)

        let input = [| yield! French |]
        o2.Load input

        Assert.AreNotEqual(o1, o2)
        Assert.AreEqual(NinCFGLanguage.AUTO, o1.Language)
        Assert.AreEqual(NinCFGLanguage.FRENCH, o2.Language)

        let data = o2.Export ()
        Assert.AreEqual (French, List.ofArray data)

    [<TestMethod>]
    member this.TestParseFail1 () =
        let o2 = new NintendontConfiguration ()

        let input = [| yield! French |]
        input.[0] <- 0x02uy
        o2.Load input

        let data = o2.Export ()
        Assert.AreEqual (ExpectedDefault, List.ofArray data)

    [<TestMethod>]
    member this.TestParseFail2 () =
        let o2 = new NintendontConfiguration ()

        let input: byte[] = Array.empty
        o2.Load input

        let data = o2.Export ()
        Assert.AreEqual (ExpectedDefault, List.ofArray data)
