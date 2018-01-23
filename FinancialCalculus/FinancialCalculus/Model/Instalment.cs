using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialCalculus.Model
{
    public class Instalment
    {
        public DateTime DueDate { get; set; }

        public double Value { get; set; }

        public double AmortizationValue { get; set; }
    }
}
