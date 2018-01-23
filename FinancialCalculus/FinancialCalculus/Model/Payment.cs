using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialCalculus.Model
{
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
}
