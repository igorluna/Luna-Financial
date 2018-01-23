using FinancialCalculus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LunaFinancialTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ThreeInstalmentTest()
        {
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 02, 01);
            double initialDebt = 600.00;
            int numberOfInstalment = 3;
            double rate = 0.05;//5,00%

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(result.FinalDebt, 660.99, "The FinalDebt is not as espected");
        }

        [TestMethod]
        public void OneInstalmentTest()
        {
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 02, 01);
            double initialDebt = 1000;
            int numberOfInstalment = 1;
            double rate = 0.05;//5,00%

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(result.FinalDebt, 1050.00, "The FinalDebt is not as espected");
        }

        [TestMethod]
        public void TwelveInstalmentInstallmentTest()
        {
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 04, 05);
            double initialDebt = 350;
            int numberOfInstalment = 12;
            double rate = 0.15;//15,00%

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(result.FinalDebt, 1045.20, "The FinalDebt is not as espected");
        }
    }
}
