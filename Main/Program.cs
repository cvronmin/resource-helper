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
            var rand = new CRMKJK.CRMRandom(200107317);
            var oriseed = rand.SeedArray.Clone();
            var results = new double[87];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = rand.NextDouble(0, 100);
            }
            Assert.AreEqual(200107317, CRMKJK.RandomUtils.GetSeed(0, 100, results));
        }
    }
}
