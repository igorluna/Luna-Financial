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
        public void ThreeInstalmentFinalDebtTest()
        {
            //Setup
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 02, 01);
            double initialDebt = 600.00;
            int numberOfInstalment = 3;
            double rate = 0.05;//5,00%

            //Expected
            double finalDebt = 660.99;

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(result.FinalDebt, finalDebt, "The FinalDebt is not as espected");
        }

        [TestMethod]
        public void ThreeInstalmentPMTTest()
        {
            //Setup
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 02, 01);
            double initialDebt = 600.00;
            int numberOfInstalment = 3;
            double rate = 0.05;//5,00%

            //Expected
            double pmt = 220.33;

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(result.PMT, pmt, "The PMT is not as espected");
        }

        [TestMethod]
        public void OneInstalmentFinalDebtTest()
        {
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 02, 01);
            double initialDebt = 1000;
            int numberOfInstalment = 1;
            double rate = 0.05;//5,00%

            //Expected
            double finalDebt = 1050.00;

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(result.FinalDebt, finalDebt, "The FinalDebt is not as espected");
        }

        [TestMethod]
        public void OneInstalmentPMTTest()
        {
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 02, 01);
            double initialDebt = 1000;
            int numberOfInstalment = 1;
            double rate = 0.05;//5,00%

            //Expected
            double pmt = 1050.00;

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(result.PMT, pmt, "The PMT is not as espected");
        }

        [TestMethod]
        public void TwelveInstalmentTest()
        {
            //Parameters
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 04, 05);
            double initialDebt = 350;
            int numberOfInstalment = 12;
            double rate = 0.15;//15,00%

            //Expected
            double finalDebt = 1045.20;

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(result.FinalDebt, finalDebt, "The FinalDebt is not as espected");
        }

        [TestMethod]
        public void FractionedDebtAndRateTest()
        {
            //Parameters
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 03, 15);
            double initialDebt = 182.47;
            int numberOfInstalment = 4;
            double rate = 0.1499;//14,99%

            //Expected
            double finalDebt = 314.48;

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(finalDebt, result.FinalDebt, "The FinalDebt is not as espected");
        }

        [TestMethod]
        public void OneDollarDebtTest()
        {
            //Parameters
            DateTime initialDate = new DateTime(2018, 01, 01);
            DateTime firstInstalment = new DateTime(2018, 02, 05);
            double initialDebt = 1;
            int numberOfInstalment = 12;
            double rate = 0.1499;//14,99%

            //Expected
            double finalDebt = 2.28;

            var result = LunaFinancial.GetPaymentByInstalment(initialDate, firstInstalment, initialDebt, numberOfInstalment, rate, true);

            Assert.AreEqual(finalDebt, result.FinalDebt, "The FinalDebt is not as espected");
        }
    }
}
