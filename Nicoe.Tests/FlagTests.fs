namespace Nicoe.Tests

open Nicoe.Configuration.V10
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type FlagTests () =
    [<TestMethod>]
    member __.TestVideoHigh () =
        use o1 = new NintendontConfiguration ()
        o1.VideoMode <- enum<NinCFGVideoMode> -1
        Assert.AreEqual (enum<NinCFGVideoMode> 0x70000, o1.VideoMode)

    [<TestMethod>]
    member __.TestVideoLow () =
        use o1 = new NintendontConfiguration ()
        o1.ForcedVideoMode <- enum<NinCFGForcedVideoMode> -1
        Assert.AreEqual (enum<NinCFGForcedVideoMode> 0xF, o1.ForcedVideoMode)