using System;

namespace P03.SumTime
{
    public class Time
    {
        public int Days { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var time1 = Console.ReadLine();
            var time2 = Console.ReadLine();

            var result = new Time();

            if (time1.Contains("::"))
            {
                var index = time1.IndexOf("::");
                var days = int.Parse(time1.Substring(0, index));

                time1 = time1.Substring(index + 2);

                result.Days += days;
            }

            var data1 = time1.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            var hours1 = int.Parse(data1[0]);
            var minutes1 = int.Parse(data1[1]);

            result.Hours += hours1;
            result.Minutes += minutes1;


            if (time2.Contains("::"))
            {
                var index = time2.IndexOf("::");
                var days = int.Parse(time2.Substring(0, index));

                time2 = time2.Substring(index + 2);

                result.Days += days;
            }

            var data2 = time2.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            var hours2 = int.Parse(data2[0]);
            var minutes2 = int.Parse(data2[1]);

            result.Hours += hours2;
            result.Minutes += minutes2;

            var output = "";

            if (result.Minutes >= 60)
            {
                var hours = result.Minutes / 60;
                var minutes = result.Minutes % 60;

                result.Hours += hours;
                result.Minutes = minutes;
            }

            if (result.Hours >= 24)
            {
                var days = result.Hours / 24;
                var hours = result.Hours % 24;

                result.Days += days;
                result.Hours = hours;
            }

            if (result.Days != 0)
            {
                output += result.Days.ToString() + "::";
            }

            output += result.Hours.ToString() + ":";

            if (result.Minutes >= 10)
            {
                output += result.Minutes.ToString();
            }
            else
            {
                output += "0" + result.Minutes.ToString();
            }

            Console.WriteLine(output);
        }
    }
}
