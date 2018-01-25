using FinancialCalculus.Extentions;
using FinancialCalculus.Model;
using System;
using System.Collections.Generic;

namespace FinancialCalculus
{
    public class LunaFinancial
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Payment GetPaymentByInstalment(DateTime initialDay, DateTime firstPayment, double initialDebt, int periods, double rate, bool firstDueEndOfPeriod)
        {
            Payment payment = new Payment();
            payment.InitialDate = initialDay;
            payment.InitialDebt = initialDebt;

            //Composing the first instalment
            double totalDebit = TotalDebitByEndOfPeriod(initialDay, firstPayment, initialDebt, rate);

            //Calculating PMT
            double pmt = Math.Round(PMT(periods, rate, totalDebit, false), 2);

            payment.PMT = pmt;
            payment.FinalDebt = Math.Round(pmt * periods, 2);

            return payment;
        }

        public static double PMT(int periods, double rate, double totalDebit, bool firstDueEndOfPeriod)
        {
            double pmt;

            if (firstDueEndOfPeriod)
            {
                double coefficient = rate / (1 - (1 / Math.Pow(1 + rate, periods)));
                pmt = coefficient * totalDebit;
            }
            else
            {
                if (periods == 1)
                {
                    pmt = totalDebit;
                }
                else
                {
                    double coefficient = rate / (1 - (1 / Math.Pow(1 + rate, periods - 1)));
                    pmt = Math.Round((totalDebit * coefficient) / (1 + coefficient), 2);
                }
            }

            return pmt;
        }

        private static double TotalDebitByEndOfPeriod(DateTime initialDay, DateTime firstPayment, double initialDebt, double rate)
        {
            DateTime firstInstallmentIndex = new DateTime();

            DateTime installmentAtInitialMonth = new DateTime(initialDay.Year, initialDay.Month, firstPayment.Day);

            firstInstallmentIndex = installmentAtInitialMonth >= initialDay ?
                                installmentAtInitialMonth :
                                installmentAtInitialMonth.AddMonths(1);

            double totalDebt = initialDebt;
            DateTime initialPeriod = new DateTime(initialDay.Year, initialDay.Month, initialDay.Day);
            while (firstInstallmentIndex <= firstPayment)
            {
                double days = initialPeriod.Days360(firstInstallmentIndex);

                double interest = rate * totalDebt * (days / 30);
                totalDebt += interest;

                initialPeriod = firstInstallmentIndex;
                firstInstallmentIndex = firstInstallmentIndex.AddMonths(1);
            }

            return totalDebt;
        }
    }

}
