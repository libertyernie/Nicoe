using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nicoe.Tests {
    [TestClass]
    public class ConstructorTests {
        private readonly string ExpectedDefault = $"01070CF6 0000000A 00000000 00000000 FFFFFFFF {string.Join("", Enumerable.Repeat("00", 256))} {string.Join("", Enumerable.Repeat("00", 256))} 00000004 00000000 02 00 00 00 00000000".Replace(" ", "");
        private readonly string French = $"01070CF6 0000000A 00000000 00000000 00000002 {string.Join("", Enumerable.Repeat("00", 256))} {string.Join("", Enumerable.Repeat("00", 256))} 00000004 00000000 02 00 00 00 00000000".Replace(" ", "");

        [TestMethod]
        public void TestDefaultConstructor() {
            var o1 = new NintendontConfiguration();
            byte[] data = o1.Export();
            Assert.AreEqual(548, data.Length);
            Assert.AreEqual(
                ExpectedDefault,
                string.Join("", data.Select(x => $"{x:X2}")));
        }

        [TestMethod]
        public void TestParseSuccess() {
            IEnumerable<byte> parseStr() {
                for (int i = 0; i < French.Length; i += 2)
                    yield return byte.Parse(French.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            var o1 = new NintendontConfiguration();
            var o2 = new NintendontConfiguration();
            byte[] input = parseStr().ToArray();
            o2.Load(input);
            Assert.AreNotEqual(o1, o2);
            Assert.AreEqual(NinCFGLanguage.AUTO, o1.Language);
            Assert.AreEqual(NinCFGLanguage.FRENCH, o2.Language);
            byte[] data = o2.Export();
            Assert.AreEqual(
                French,
                string.Join("", data.Select(x => $"{x:X2}")));
        }

        [TestMethod]
        public void TestParseFail() {
            IEnumerable<byte> parseStr() {
                for (int i = 0; i < French.Length; i += 2)
                    yield return byte.Parse(French.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            var o1 = new NintendontConfiguration();
            var o2 = new NintendontConfiguration();
            byte[] input = parseStr().ToArray();
            input[0]++;
            o2.Load(input);
            Assert.AreEqual(o1, o2);
        }
    }
}
