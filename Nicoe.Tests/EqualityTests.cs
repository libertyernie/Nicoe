using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nicoe.Tests {
    [TestClass]
    public class EqualityTests {
        [TestMethod]
        public void TestDefaultEquality() {
            var o1 = new NintendontConfiguration();
            var o2 = new NintendontConfiguration();
            Assert.IsFalse(o1 == o2);
            Assert.IsTrue(o1.Equals(o2));
        }
    }
}
