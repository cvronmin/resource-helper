using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ResourceHelper());
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MyTestClass
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void MyTestMethod()
        {
            var rand = new CRMKJK.CRMRandom(20010817);
            var oriseed = rand.SeedArray.Clone();
            var results = new double[87];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = rand.NextDouble(0, 100);
            }
            Assert.AreEqual(20010817, CRMKJK.RandomUtils.GetSeed(0, 100, results));
        }

        [TestMethod]
        public void MyTestMethod1()
        {
            var aray = new char[] { 'I', ' ', 'a', 'm', 'T', 'i', 'g', 'e', 'r', 'H', 'u'};
            var bytearay = System.Text.Encoding.UTF8.GetBytes(aray);
            var intaray = bytearay.Select(b => (int)b);
            int seed = CRMKJK.RandomUtils.GetSeed(32, 96, intaray.ToArray());
            var rand = new CRMKJK.CRMRandom(seed);
            var test = new byte[aray.Length];
            for (int i = 0; i < test.Length; i++)
            {
                test[i] = (byte)rand.Next(32,96);
            }
            var chartest = System.Text.Encoding.UTF8.GetChars(test);
            Assert.AreEqual(aray, chartest);
        }
    }
}
