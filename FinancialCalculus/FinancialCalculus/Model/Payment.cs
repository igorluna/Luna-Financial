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
        private DateTime _initialDate;

        public DateTime InitialDate
        {
            get { return _initialDate; }
            set { _initialDate = value; }
        }

        public double InitialDebt { get; set; }

        public double FinalDebt { get; set; }

        public double PMT { get; set; }

        public List<Instalment> Instalments { get; set; }
    }
}
