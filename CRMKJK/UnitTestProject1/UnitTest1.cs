using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string a = "行成於思敗於隨";
            Assert.AreEqual(a, CRMKJK.CRMKJK.Decode(CRMKJK.CRMKJK.Encode(a)));
        }
        [TestMethod]
        [ExpectedException(typeof(CRMKJK.UnexpectedCRMKJKEncodeException))]
        public void TestMethod3() {
            string b = "nasoty345080-=/.";
            Assert.AreEqual(b,CRMKJK.CRMKJK.Encode(CRMKJK.CRMKJK.Decode(b)));
        }
    }
}
