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

            double totalDebit = GetTotalDebitByEndOfPeriod(initialDay, firstPayment, initialDebt, rate);

            //Now, with the  debit after the first installment, the instalments will be expected to be monthly with fixed days apart of each one.

            //Calculating PMT
            double pmt = Math.Round(PMT(periods, rate, totalDebit, false), 2);

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

        private static double GetTotalDebitByEndOfPeriod(DateTime initialDay, DateTime firstPayment, double initialDebt, double rate)
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
                //TODO Calcular dias contábil
                double days = (firstInstallmentIndex - initialPeriod).TotalDays;
                if (days > 30) days = 30;

                totalDebt += rate * totalDebt * (days / 30);
                firstInstallmentIndex = firstInstallmentIndex.AddMonths(1);
            }

            return totalDebt;
        }
    }

    public class Payment
    {
        public Payment()
        {
            Instalments = new List<Instalment>();
        }

        public DateTime InitialDate { get; set; }

        public double InitialDebt { get; set; }

        public double FinalDebt { get; set; }

        public List<Instalment> Instalments { get; set; }
    }

    public class Instalment
    {
        public DateTime DueDate { get; set; }

        public double Value { get; set; }

        public double AmortizationValue { get; set; }
    }
}
