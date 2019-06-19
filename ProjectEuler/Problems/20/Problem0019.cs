using System;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Counting Sundays
    /// </summary>
    public class Problem0019
    {
        public object GetResult()
        {
            var date = new DateTime(1901, 1, 1);
            var maxDate = new DateTime(2000, 12, 31);

            int sundaysCount = 0;

            while (date < maxDate)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                    sundaysCount++;

                date = date.AddMonths(1);
            }

            return sundaysCount;
        }
    }
}