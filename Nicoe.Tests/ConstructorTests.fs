namespace Nicoe.Tests

open System
open Nicoe.Configuration.V10
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
    member __.TestDefaultConstructor () =
        use o1 = new NintendontConfiguration ()
        let data = o1.Export ()
        Assert.AreEqual (548, data.Length)
        Assert.AreEqual (ExpectedDefault, List.ofArray data)

    [<TestMethod>]
    member __.TestParseSuccess () =
        use o1 = new NintendontConfiguration ()
        use o2 = new NintendontConfiguration ()

        Assert.AreEqual(o1, o2)

        let input = [| yield! French |]
        o2.Load input

        Assert.AreNotEqual(o1, o2)
        Assert.AreEqual(NinCFGLanguage.AUTO, o1.Language)
        Assert.AreEqual(NinCFGLanguage.FRENCH, o2.Language)

        let data = o2.Export ()
        Assert.AreEqual (French, List.ofArray data)

    [<TestMethod>]
    member __.TestParseFail1 () =
        use o2 = new NintendontConfiguration ()

        let input = [| yield! French |]
        input.[0] <- 0x02uy
        o2.Load input

        let data = o2.Export ()
        Assert.AreEqual (ExpectedDefault, List.ofArray data)

    [<TestMethod>]
    member __.TestParseFail2 () =
        use o2 = new NintendontConfiguration ()

        let input: byte[] = Array.empty
        o2.Load input

        let data = o2.Export ()
        Assert.AreEqual (ExpectedDefault, List.ofArray data)

    [<TestMethod>]
    member __.TestParseFail3 () =
        use o2 = new NintendontConfiguration ()

        let input = [| for _ in [0..1000] do 0uy |]
        o2.Load input

        let data = o2.Export ()
        Assert.AreEqual (ExpectedDefault, List.ofArray data)

    [<TestMethod>]
    member __.TestUpgradeFrom8 () =
        use o1 = new NintendontConfiguration ()

        [
            "01070cf6000000080000418800000014"
            "ffffffff2f67616d65732f42696c6c79"
            "204861746368657220616e6420746865"
            "204769616e74204567672f67616d652e"
            "69736f00000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "00000000000000000000000000000000"
            "000000000000000447455a4500000000"
        ]
        |> ToByteList
        |> Seq.toArray
        |> o1.Load

        let data = o1.Export ()
        Assert.AreNotEqual (544, data.Length)
        Assert.AreEqual (548, data.Length)

        Assert.AreEqual ("GEZE", o1.GameID)
        Assert.IsTrue o1.MEMCARDEMU
        Assert.IsTrue o1.AUTO_BOOT
        Assert.IsTrue o1.REMLIMIT
        Assert.IsTrue o1.NATIVE_SI
        Assert.IsFalse o1.CC_RUMBLE
        Assert.IsFalse o1.MC_MULTI
        Assert.AreEqual ("/games/Billy Hatcher and the Giant Egg/game.iso", o1.GamePath)
        Assert.AreEqual (NinCFGVideoMode.AUTO, o1.VideoMode)
        Assert.AreEqual (NinCFGForcedVideoMode.NTSC, o1.ForcedVideoMode)
