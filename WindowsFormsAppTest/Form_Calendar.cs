using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Astro;

namespace WindowsFormsAppTest
{
    public partial class Form_Calendar : Form
    {
        public Form_Calendar()
        {
            InitializeComponent();
        }

        private ChrisCalendar cal = new ChrisCalendar();
        private SlavCalendar scal = new SlavCalendar();

        private void Form_Calendar_Load(object sender, EventArgs e)
        {
            PrintCalendar();
            SPrintCalendar();
        }
        
        // Выведение Христианского календаря
        private void PrintCalendar()
        {
            label1.Text = cal.Year.ToString();
            label45.Text = cal.MonthString(cal.Month);
            
            PrintDay(label3, cal.MonthArr[0, 0]);
            PrintDay(label4, cal.MonthArr[1, 0]);
            PrintDay(label5, cal.MonthArr[2, 0]);
            PrintDay(label6, cal.MonthArr[3, 0]);
            PrintDay(label7, cal.MonthArr[4, 0]);
            PrintDay(label8, cal.MonthArr[5, 0]);
            PrintDay(label9, cal.MonthArr[6, 0]);
            PrintDay(label16, cal.MonthArr[0, 1]);
            PrintDay(label15, cal.MonthArr[1, 1]);
            PrintDay(label14, cal.MonthArr[2, 1]);
            PrintDay(label13, cal.MonthArr[3, 1]);
            PrintDay(label12, cal.MonthArr[4, 1]);
            PrintDay(label11, cal.MonthArr[5, 1]);
            PrintDay(label10, cal.MonthArr[6, 1]);
            PrintDay(label23, cal.MonthArr[0, 2]);
            PrintDay(label22, cal.MonthArr[1, 2]);
            PrintDay(label21, cal.MonthArr[2, 2]);
            PrintDay(label20, cal.MonthArr[3, 2]);
            PrintDay(label19, cal.MonthArr[4, 2]);
            PrintDay(label18, cal.MonthArr[5, 2]);
            PrintDay(label17, cal.MonthArr[6, 2]);
            PrintDay(label30, cal.MonthArr[0, 3]);
            PrintDay(label29, cal.MonthArr[1, 3]);
            PrintDay(label28, cal.MonthArr[2, 3]);
            PrintDay(label27, cal.MonthArr[3, 3]);
            PrintDay(label26, cal.MonthArr[4, 3]);
            PrintDay(label25, cal.MonthArr[5, 3]);
            PrintDay(label24, cal.MonthArr[6, 3]);
            PrintDay(label37, cal.MonthArr[0, 4]);
            PrintDay(label36, cal.MonthArr[1, 4]);
            PrintDay(label35, cal.MonthArr[2, 4]);
            PrintDay(label34, cal.MonthArr[3, 4]);
            PrintDay(label33, cal.MonthArr[4, 4]);
            PrintDay(label32, cal.MonthArr[5, 4]);
            PrintDay(label31, cal.MonthArr[6, 4]);
            PrintDay(label44, cal.MonthArr[0, 5]);
            PrintDay(label43, cal.MonthArr[1, 5]);
            PrintDay(label42, cal.MonthArr[2, 5]);
            PrintDay(label41, cal.MonthArr[3, 5]);
            PrintDay(label40, cal.MonthArr[4, 5]);
            PrintDay(label39, cal.MonthArr[5, 5]);
            PrintDay(label38, cal.MonthArr[6, 5]);
        }
        private void PrintDay(Label label, DateInfo dateInfo)
        {
            if (dateInfo.chris.month == cal.Month)
            { 
                label.Text = dateInfo.chris.day.ToString();
            }
            else
            {
                label.Text = null;
            }
            
            if(dateInfo.slav.holiday != "") label.BackColor = Color.Brown;
            if (cal.Month == DateTime.Now.Month && cal.Year == DateTime.Now.Year && dateInfo.chris.day == DateTime.Now.Day)
            { 
                label.BackColor = Color.DarkBlue;
            }
        }
        // Выведение Славянского календаря
        private void SPrintCalendar()
        {
            label47.Text = scal.Year.ToString();
            label48.Text = scal.MonthString(scal.Month);

            SPrintDay(label55, scal.MonthArr[0, 0]);
            SPrintDay(label54, scal.MonthArr[1, 0]);
            SPrintDay(label53, scal.MonthArr[2, 0]);
            SPrintDay(label52, scal.MonthArr[3, 0]);
            SPrintDay(label51, scal.MonthArr[4, 0]);
            SPrintDay(label50, scal.MonthArr[5, 0]);
            SPrintDay(label49, scal.MonthArr[6, 0]);
            SPrintDay(label56, scal.MonthArr[7, 0]);
            SPrintDay(label57, scal.MonthArr[8, 0]);
            SPrintDay(label66, scal.MonthArr[0, 1]);
            SPrintDay(label65, scal.MonthArr[1, 1]);
            SPrintDay(label64, scal.MonthArr[2, 1]);
            SPrintDay(label63, scal.MonthArr[3, 1]);
            SPrintDay(label62, scal.MonthArr[4, 1]);
            SPrintDay(label61, scal.MonthArr[5, 1]);
            SPrintDay(label60, scal.MonthArr[6, 1]);
            SPrintDay(label59, scal.MonthArr[7, 1]);
            SPrintDay(label58, scal.MonthArr[8, 1]);
            SPrintDay(label75, scal.MonthArr[0, 2]);
            SPrintDay(label74, scal.MonthArr[1, 2]);
            SPrintDay(label73, scal.MonthArr[2, 2]);
            SPrintDay(label72, scal.MonthArr[3, 2]);
            SPrintDay(label71, scal.MonthArr[4, 2]);
            SPrintDay(label70, scal.MonthArr[5, 2]);
            SPrintDay(label69, scal.MonthArr[6, 2]);
            SPrintDay(label68, scal.MonthArr[7, 2]);
            SPrintDay(label67, scal.MonthArr[8, 2]);
            SPrintDay(label84, scal.MonthArr[0, 3]);
            SPrintDay(label83, scal.MonthArr[1, 3]);
            SPrintDay(label82, scal.MonthArr[2, 3]);
            SPrintDay(label81, scal.MonthArr[3, 3]);
            SPrintDay(label80, scal.MonthArr[4, 3]);
            SPrintDay(label79, scal.MonthArr[5, 3]);
            SPrintDay(label78, scal.MonthArr[6, 3]);
            SPrintDay(label77, scal.MonthArr[7, 3]);
            SPrintDay(label76, scal.MonthArr[8, 3]);
            SPrintDay(label93, scal.MonthArr[0, 4]);
            SPrintDay(label92, scal.MonthArr[1, 4]);
            SPrintDay(label91, scal.MonthArr[2, 4]);
            SPrintDay(label90, scal.MonthArr[3, 4]);
            SPrintDay(label89, scal.MonthArr[4, 4]);
            SPrintDay(label88, scal.MonthArr[5, 4]);
            SPrintDay(label87, scal.MonthArr[6, 4]);
            SPrintDay(label86, scal.MonthArr[7, 4]);
            SPrintDay(label85, scal.MonthArr[8, 4]);
            SPrintDay(label102, scal.MonthArr[0, 5]);
            SPrintDay(label101, scal.MonthArr[1, 5]);
            SPrintDay(label100, scal.MonthArr[2, 5]);
            SPrintDay(label99, scal.MonthArr[3, 5]);
            SPrintDay(label98, scal.MonthArr[4, 5]);
            SPrintDay(label97, scal.MonthArr[5, 5]);
            SPrintDay(label96, scal.MonthArr[6, 5]);
            SPrintDay(label95, scal.MonthArr[7, 5]);
            SPrintDay(label94, scal.MonthArr[8, 5]);
        }
        private void SPrintDay(Label label, DateInfo dateInfo)
        {
            if (dateInfo.slav.slavMonth == scal.Month)
            {
                label.Text = dateInfo.slav.slavDay.ToString();
            }
            else
            {
                label.Text = null;
            }

            if (dateInfo.slav.holiday != "") label.BackColor = Color.Brown;
            if ( dateInfo.slav.slavMonth == SlavCalendar.monthtoday && dateInfo.slav.slavYear == SlavCalendar.yeartoday && dateInfo.slav.slavDay == SlavCalendar.daytoday)
            {
                label.BackColor = Color.DarkBlue;
            }
        }

        // Навигация по Христианскому календарю
        private void button1_Click(object sender, EventArgs e)
        {
            cal.Month -= 1;
            LabelClear();
            textBox1.Text = null;
            PrintCalendar();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cal.Month += 1;
            LabelClear();
            textBox1.Text = null;
            PrintCalendar();
        }
        private void LabelClear()
        {
            label3.BackColor = Color.Black;
            label4.BackColor = Color.Black;
            label5.BackColor = Color.Black;
            label6.BackColor = Color.Black;
            label7.BackColor = Color.Black;
            label8.BackColor = Color.Black;
            label9.BackColor = Color.Black;
            label10.BackColor = Color.Black;
            label11.BackColor = Color.Black;
            label12.BackColor = Color.Black;
            label13.BackColor = Color.Black;
            label14.BackColor = Color.Black;
            label15.BackColor = Color.Black;
            label16.BackColor = Color.Black;
            label17.BackColor = Color.Black;
            label18.BackColor = Color.Black;
            label19.BackColor = Color.Black;
            label20.BackColor = Color.Black;
            label21.BackColor = Color.Black;
            label22.BackColor = Color.Black;
            label23.BackColor = Color.Black;
            label24.BackColor = Color.Black;
            label25.BackColor = Color.Black;
            label26.BackColor = Color.Black;
            label27.BackColor = Color.Black;
            label28.BackColor = Color.Black;
            label29.BackColor = Color.Black;
            label30.BackColor = Color.Black;
            label31.BackColor = Color.Black;
            label32.BackColor = Color.Black;
            label33.BackColor = Color.Black;
            label34.BackColor = Color.Black;
            label35.BackColor = Color.Black;
            label36.BackColor = Color.Black;
            label37.BackColor = Color.Black;
            label38.BackColor = Color.Black;
            label39.BackColor = Color.Black;
            label40.BackColor = Color.Black;
            label41.BackColor = Color.Black;
            label42.BackColor = Color.Black;
            label43.BackColor = Color.Black;
            label44.BackColor = Color.Black;
        }
        // навигация по Славянскому календарю
        private void button4_Click(object sender, EventArgs e)
        {
            scal.Month -= 1;
            scal.dir = -1;
            scal.firstday = scal.firstday.AddDays(-1);
            scal.Fday = new DateInfo(scal.firstday).slav.slavDay;
            SLabelClear();
            textBox1.Text = null;
            SPrintCalendar();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            scal.Month += 1;
            scal.dir = 1;
            scal.firstday = scal.firstday.AddDays(1);
            scal.Fday = new DateInfo(scal.firstday).slav.slavDay;
            SLabelClear();
            textBox1.Text = null;
            SPrintCalendar();
        }
        private void SLabelClear()
        {
            label55.BackColor = Color.Black;
            label54.BackColor = Color.Black;
            label53.BackColor = Color.Black;
            label52.BackColor = Color.Black;
            label51.BackColor = Color.Black;
            label50.BackColor = Color.Black;
            label49.BackColor = Color.Black;
            label56.BackColor = Color.Black;
            label57.BackColor = Color.Black;
            label66.BackColor = Color.Black;
            label65.BackColor = Color.Black;
            label64.BackColor = Color.Black;
            label63.BackColor = Color.Black;
            label62.BackColor = Color.Black;
            label61.BackColor = Color.Black;
            label60.BackColor = Color.Black;
            label59.BackColor = Color.Black;
            label58.BackColor = Color.Black;
            label75.BackColor = Color.Black;
            label74.BackColor = Color.Black;
            label73.BackColor = Color.Black;
            label72.BackColor = Color.Black;
            label71.BackColor = Color.Black;
            label70.BackColor = Color.Black;
            label69.BackColor = Color.Black;
            label68.BackColor = Color.Black;
            label67.BackColor = Color.Black;
            label84.BackColor = Color.Black;
            label83.BackColor = Color.Black;
            label82.BackColor = Color.Black;
            label81.BackColor = Color.Black;
            label80.BackColor = Color.Black;
            label79.BackColor = Color.Black;
            label78.BackColor = Color.Black;
            label77.BackColor = Color.Black;
            label76.BackColor = Color.Black;
            label93.BackColor = Color.Black;
            label92.BackColor = Color.Black;
            label91.BackColor = Color.Black;
            label90.BackColor = Color.Black;
            label89.BackColor = Color.Black;
            label88.BackColor = Color.Black;
            label87.BackColor = Color.Black;
            label86.BackColor = Color.Black;
            label85.BackColor = Color.Black;
            label102.BackColor = Color.Black;
            label101.BackColor = Color.Black;
            label100.BackColor = Color.Black;
            label99.BackColor = Color.Black;
            label98.BackColor = Color.Black;
            label97.BackColor = Color.Black;
            label96.BackColor = Color.Black;
            label95.BackColor = Color.Black;
            label94.BackColor = Color.Black;
        }

        private void DayDescription(DateInfo dateInfo)
        {
            textBox1.Text = "Лѣто " + dateInfo.slav.slavYear + ", " + dateInfo.slav.slavDay + " " + dateInfo.slav.slavMonthName + "(" +
                    dateInfo.slav.slavMonth + ") " + dateInfo.slav.slavDayName + ", " + dateInfo.slav.slavSeason + Environment.NewLine +
                    dateInfo.slav.holiday;
        }
        // Описание событий дня по Христианскому календарю
        #region Day Desctiption
        private void label3_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[0, 0]);
        }
        private void label4_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[1, 0]);
        }
        private void label5_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[2, 0]);
        }
        private void label6_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[3, 0]);
        }
        private void label7_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[4, 0]);
        }
        private void label8_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[5, 0]);
        }
        private void label9_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[6, 0]);
        }
        private void label16_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[0, 1]);
        }
        private void label15_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[1, 1]);
        }
        private void label14_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[2, 1]);
        }
        private void label13_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[3, 1]);
        }
        private void label12_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[4, 1]);
        }
        private void label11_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[5, 1]);
        }
        private void label10_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[6, 1]);
        }
        private void label23_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[0, 2]);
        }
        private void label22_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[1, 2]);
        }
        private void label21_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[2, 2]);
        }
        private void label20_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[3, 2]);
        }
        private void label19_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[4, 2]);
        }
        private void label18_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[5, 2]);
        }
        private void label17_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[6, 2]);
        }
        private void label30_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[0, 3]);
        }
        private void label29_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[1, 3]);
        }
        private void label28_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[2, 3]);
        }
        private void label27_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[3, 3]);
        }
        private void label26_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[4, 3]);
        }
        private void label25_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[5, 3]);
        }
        private void label24_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[6, 3]);
        }
        private void label37_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[0, 4]);
        }
        private void label36_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[1, 4]);
        }
        private void label35_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[2, 4]);
        }
        private void label34_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[3, 4]);
        }
        private void label33_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[4, 4]);
        }
        private void label32_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[5, 4]);
        }
        private void label31_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[6, 4]);
        }
        private void label44_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[0, 5]);
        }
        private void label43_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[1, 5]);
        }
        private void label42_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[2, 5]);
        }
        private void label41_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[3, 5]);
        }
        private void label40_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[4, 5]);
        }
        private void label39_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[5, 5]);
        }
        private void label38_Click(object sender, EventArgs e)
        {
            DayDescription(cal.MonthArr[6, 5]);
        }
        #endregion
        // Описание событий дня по Славянскому календарю
        #region Day Desctiption
        private void label55_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[0, 0]);
        }
        private void label54_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[1, 0]);
        }
        private void label53_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[2, 0]);
        }
        private void label52_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[3, 0]);
        }
        private void label51_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[4, 0]);
        }
        private void label50_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[5, 0]);
        }
        private void label49_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[6, 0]);
        }
        private void label56_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[7, 0]);
        }
        private void label57_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[8, 0]);
        }
        private void label66_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[0, 1]);
        }
        private void label65_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[1, 1]);
        }
        private void label64_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[2, 1]);
        }
        private void label63_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[3, 1]);
        }
        private void label62_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[4, 1]);
        }
        private void label61_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[5, 1]);
        }
        private void label60_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[6, 1]);
        }
        private void label59_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[7, 1]);
        }
        private void label58_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[8, 1]);
        }
        private void label75_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[0, 2]);
        }
        private void label74_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[1, 2]);
        }
        private void label73_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[2, 2]);
        }
        private void label72_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[3, 2]);
        }
        private void label71_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[4, 2]);
        }
        private void label70_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[5, 2]);
        }
        private void label69_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[6, 2]);
        }
        private void label68_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[7, 2]);
        }
        private void label67_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[8, 2]);
        }
        private void label84_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[0, 3]);
        }
        private void label83_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[1, 3]);
        }
        private void label82_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[2, 3]);
        }
        private void label81_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[3, 3]);
        }
        private void label80_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[4, 3]);
        }
        private void label79_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[5, 3]);
        }
        private void label78_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[6, 3]);
        }
        private void label77_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[7, 3]);
        }
        private void label76_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[8, 3]);
        }
        private void label93_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[0, 4]);
        }
        private void label92_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[1, 4]);
        }
        private void label91_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[2, 4]);
        }
        private void label90_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[3, 4]);
        }
        private void label89_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[4, 4]);
        }
        private void label88_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[5, 4]);
        }
        private void label87_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[6, 4]);
        }
        private void label86_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[7, 4]);
        }
        private void label85_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[8, 4]);
        }
        private void label102_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[0, 5]);
        }
        private void label101_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[1, 5]);
        }
        private void label100_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[2, 5]);
        }
        private void label99_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[3, 5]);
        }
        private void label98_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[4, 5]);
        }
        private void label97_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[5, 5]);
        }
        private void label96_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[6, 5]);
        }
        private void label95_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[7, 5]);
        }
        private void label94_Click(object sender, EventArgs e)
        {
            DayDescription(scal.MonthArr[8, 5]);
        }
        #endregion
    }
}
