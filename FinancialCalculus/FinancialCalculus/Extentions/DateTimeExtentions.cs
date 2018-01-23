using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialCalculus.Extentions
{

    public static class DateTimeExtentions
    {
        /// <summary>
        /// Method to get the number of days between dates on a financial Year of 360 days.
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns>Financial days between 2 dates</returns>
        /// <remarks>The return value allways will be between 0 and 30.</remarks>
        public static double Days360(this DateTime StartDate, DateTime EndDate)
        {
            int StartDay = StartDate.Day;
            int StartMonth = StartDate.Month;
            int StartYear = StartDate.Year;
            int EndDay = EndDate.Day;
            int EndMonth = EndDate.Month;
            int EndYear = EndDate.Year;

            if (StartDay == 31 || StartDate.IsLastDayOfFebruary())
            {
                StartDay = 30;
            }

            if (StartDay == 30 && EndDay == 31)
            {
                EndDay = 30;
            }

            return ((EndYear - StartYear) * 360) + ((EndMonth - StartMonth) * 30) + (EndDay - StartDay);
        }

        /// <summary>
        /// Check if a day is the last day of February
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsLastDayOfFebruary(this DateTime date)
        {
            return date.Month == 2 && date.Day == DateTime.DaysInMonth(date.Year, date.Month);
        }
    }
}
