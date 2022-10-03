using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public double GetDifferenceInDays(string startDate, string endDate)
        {
            int[] stDate = startDate.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] enDate = endDate.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            DateTime date1 = new DateTime(stDate[0], stDate[1], stDate[2]);
            DateTime date2 = new DateTime(enDate[0], enDate[1], enDate[2]);

            return (date2 - date1).TotalDays;
        }
    }
}
