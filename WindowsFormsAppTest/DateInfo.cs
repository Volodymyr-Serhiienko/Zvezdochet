using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astro
{
    public class Christian
    {
        private DateTime Datetime;
        public Christian(DateTime dateTime)
        {
            Datetime = dateTime;
        }
        
        public int year
        {
            get
            {
                return Datetime.Year;
            }
        }
        public int month
        {
            get
            {
                return Datetime.Month;
            }
        }
        public int day
        {
            get
            {
                return Datetime.Day;
            }
        }
        public int hour
        {
            get
            {
                return Datetime.Hour;
            }
        }
        public int min
        {
            get
            {
                return Datetime.Minute;
            }
        }
    }
    public class Slavian : Christian
    {
        public int slavYear;
        public int slavYear144;
        public int slavYear16;
        public int slavMonth;
        public string slavMonthName;
        public int slavDay;
        public string slavSeason;
        public string slavDayName;
        public string holiday;

        public Slavian(DateTime dateTime)
            : base(dateTime)
        {
            DateTime slavDate;
            if (dateTime.Hour >= 18)
            {
                slavDate = new DateTime(dateTime.AddDays(1).Year, dateTime.AddDays(1).Month, dateTime.AddDays(1).Day, dateTime.AddDays(1).Hour, dateTime.AddDays(1).Minute, dateTime.AddDays(1).Second);
            }
            else
            {
                slavDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            }

            slavYear = slavDate.Year + 5508;
            slavYear144 = (slavYear % 144) + 112; if (slavYear144 > 144) slavYear144 -= 144;
            slavYear16 = slavYear % 16; if (slavYear16 == 0) slavYear16 = 16;

            if ((slavYear16 == 1 || slavYear16 == 2 || slavYear16 == 3 || slavYear16 == 4) && ((slavDate.Month >= 9 && slavDate.Day >= 23) || slavDate.Month >= 10)) // 16
            {
                slavYear += 1; slavYear144 += 1; slavYear16 += 1;
            }
            else if ((slavYear16 == 5 || slavYear16 == 6 || slavYear16 == 7 || slavYear16 == 8) && ((slavDate.Month >= 9 && slavDate.Day >= 22) || slavDate.Month >= 10)) // 4
            {
                slavYear += 1; slavYear144 += 1; slavYear16 += 1;
            }
            else if ((slavYear16 == 9 || slavYear16 == 10 || slavYear16 == 11 || slavYear16 == 12) && ((slavDate.Month >= 9 && slavDate.Day >= 21) || slavDate.Month >= 10)) // 8
            {
                slavYear += 1; slavYear144 += 1; slavYear16 += 1;
            }
            else if ((slavYear16 == 13 || slavYear16 == 14 || slavYear16 == 15 || slavYear16 == 16) && ((slavDate.Month >= 9 && slavDate.Day >= 20) || slavDate.Month >= 10)) // 12
            {
                slavYear += 1; slavYear144 += 1; slavYear16 += 1;
            }
            if ((slavYear16 == 4 && slavDate.Month == 9 && slavDate.Day == 22) || (slavYear16 == 8 && slavDate.Month == 9 && slavDate.Day == 21) || (slavYear16 == 12 && slavDate.Month == 9 && slavDate.Day == 20) || (slavYear16 == 16 && slavDate.Month == 9 && slavDate.Day == 19))
            {
                slavYear += 1; slavYear144 += 1; slavYear16 += 1;
            }
            if (slavYear144 > 144) slavYear144 -= 144;
            if (slavYear16 > 16) slavYear16 -= 16;
            
            string[] slavCal = SlavAstronomy.dateConvert(slavYear16, slavDate.Month, slavDate.Day, slavDate.Year);
            slavMonth = int.Parse(slavCal[1]);
            slavMonthName = slavCal[0];
            slavDay = int.Parse(slavCal[2]);
            slavSeason = slavCal[3];
            slavDayName = SlavAstronomy.dayCalc(slavYear144, slavMonth, slavDay);
            holiday = slavCal[4];
        }
    }

    public class DateInfo
    {
        public Christian chris;
        public Slavian slav;
        public DateInfo(DateTime dateTime)
        {
            chris = new Christian(dateTime);
            slav = new Slavian(dateTime);
        }  
    }
}
