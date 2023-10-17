using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astro
{
    public class Person : AstroObject
    {
        private static DateTime TodayDate { get; } = DateTime.Now;
        public string Name { get; }
        public DateTime BirthDate { get; }
        public TimeSpan DifDate
        {
            get
            {
                return TodayDate - BirthDate;
            }
        }
        public int Age
        {
            get
            {

                return (int)(DifDate.Days / 365.25);
            }
        }
        public int LifeNum
        {
            get
            {
                int num = dateInfo.chris.year + dateInfo.chris.month + dateInfo.chris.day;
            start:
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                if (sum > 9) { num = sum; goto start; }
                return sum;
            }
        }
        public int GuardNum
        {
            get
            {
                int num = dateInfo.slav.slavYear + dateInfo.slav.slavMonth + dateInfo.slav.slavDay;
            start:
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                if (sum > 9) { num = sum; goto start; }
                return sum;
            }
        }

        public Person(DateTime datetime, string name)
            : base(datetime)
        {
            Name = name;
            BirthDate = datetime;
        }

    }
}
