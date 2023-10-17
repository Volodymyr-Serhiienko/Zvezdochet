using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Astro;

namespace WindowsFormsAppTest
{
    public abstract class Calendar
    {
        public abstract int Month { get; set; }
        public abstract int Year { get; set; }
        public abstract DateInfo[,] MonthArr { get; }

        public abstract string MonthString(int num);
        public abstract int FeedBack(DayOfWeek day_of_week);
    }
    
    public class ChrisCalendar : Calendar
    {
        private static int month;
        private static int year;
        public DateInfo[,] monthArr = new DateInfo[7, 6];

        static ChrisCalendar()
        {
            DateInfo today = new DateInfo(DateTime.Now);
            month = today.chris.month;
            year = today.chris.year;
        }
        public ChrisCalendar() {}

        public override int Month
        {
            get => month;
            set
            {
                if (value == 0)
                {
                    value = 12;
                    year -= 1;
                    month = value;
                }
                else if (value == 13)
                {
                    value = 1;
                    year += 1;
                    month = value;
                }
                else
                {
                    month = value;
                }
            }
        }
        public override int Year
        {
            get => year;
            set => year = value;
        }
        public override DateInfo[,] MonthArr
        {
            get
            {
                DateTime firstday = new DateTime(Year, Month, 1);
                DayOfWeek day_of_week = firstday.DayOfWeek;
                int feed_back = FeedBack(day_of_week);
                DateTime start_date = firstday.AddDays(-feed_back);
                for (int i = 0; i < monthArr.Length; i++)
                {
                    monthArr[i % 7, i / 7] = new DateInfo(start_date.AddDays(i));
                }
                return monthArr;
            }
        }

        public override string MonthString(int num)
        {
            switch (num)
            {
                case 1: return "Янв";
                case 2: return "Фев";
                case 3: return "Мар";
                case 4: return "Апр";
                case 5: return "Май";
                case 6: return "Июн";
                case 7: return "Июл";
                case 8: return "Авг";
                case 9: return "Сен";
                case 10: return "Окт";
                case 11: return "Ноя";
                default: return "Дек";
            }
        }
        public override int FeedBack(DayOfWeek day_of_week)
        {
            if (day_of_week == DayOfWeek.Monday) return 0;
            if (day_of_week == DayOfWeek.Tuesday) return 1;
            if (day_of_week == DayOfWeek.Wednesday) return 2;
            if (day_of_week == DayOfWeek.Thursday) return 3;
            if (day_of_week == DayOfWeek.Friday) return 4;
            if (day_of_week == DayOfWeek.Saturday) return 5;
            if (day_of_week == DayOfWeek.Sunday) return 6;
            return 0;
        }
    }

    public class SlavCalendar : Calendar
    {
        public int dir = -1;
        private string dayname;
        public static int daytoday;
        public static int monthtoday;
        public static int yeartoday;
        private static int fday;
        private static int month;
        private static int year;
        public DateInfo[,] monthArr = new DateInfo[9, 6];
        public DateTime firstday = DateTime.Now;

        static SlavCalendar()
        {
            DateInfo today = new DateInfo(DateTime.Now);
            month = today.slav.slavMonth;
            year = today.slav.slavYear;
            daytoday = today.slav.slavDay;
            fday = daytoday;
            monthtoday = today.slav.slavMonth;
            yeartoday = today.slav.slavYear;
        }
        public SlavCalendar() { }

        public int Fday
        {
            get => fday;
            set => fday = new DateInfo(firstday).slav.slavDay;
        }
        public override int Month
        {
            get => month;
            set
            {
                if (value == 0)
                {
                    value = 9;
                    year -= 1;
                    month = value;
                }
                else if (value == 10)
                {
                    value = 1;
                    year += 1;
                    month = value;
                }
                else
                {
                    month = value;
                }
            }
        }
        public override int Year
        {
            get => year;
            set => year = value;
        }
        public override DateInfo[,] MonthArr
        {
            get
            {
                if(dir == -1)
                {
                    while (Fday > 1)
                    {
                        firstday = firstday.AddDays(-1);
                        Fday--;
                    }
                }
                else
                {
                    while (Fday != 1)
                    {
                        firstday = firstday.AddDays(1);
                        Fday++;
                    }
                }
                dayname = new DateInfo(firstday).slav.slavDayName;
                DayOfWeek day_of_week = firstday.DayOfWeek; // Заглушка
                int feed_back = FeedBack(day_of_week);
                DateTime start_date = firstday.AddDays(-feed_back);
                for (int i = 0; i < monthArr.Length; i++)
                {
                    monthArr[i % 9, i / 9] = new DateInfo(start_date.AddDays(i));
                }
                return monthArr;
            }
        }

        public override string MonthString(int num)
        {
            switch(num) 
            {
                case 1: return "Рам";
                case 2: return "Айл";
                case 3: return "Бей";
                case 4: return "Гэй";
                case 5: return "Дай";
                case 6: return "Элѣ";
                case 7: return "Вэй";
                case 8: return "Хей";
                default: return "Тай";
            }
        }
        public override int FeedBack(DayOfWeek day_of_week)
        {
            if (dayname == "Понедельникъ") return 0;
            if (dayname == "Вторникъ") return 1;
            if (dayname == "Тритейникъ") return 2;
            if (dayname == "Четверикъ") return 3;
            if (dayname == "Пятница") return 4;
            if (dayname == "Шестица") return 5;
            if (dayname == "Седьмица") return 6;
            if (dayname == "Осьмица") return 7;
            if (dayname == "Неделя") return 8;
            return 0;
        }
    }
}
