using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Astro;

namespace WindowsFormsAppTest
{
    public partial class Form_UserOpen : Form
    {
        public Form_UserOpen()
        {
            InitializeComponent();
        }

        private void Form4_UserOpen_Load(object sender, EventArgs e)
        {
            DBconnect db = DBconnect.getDataBase();
            string sqlExpression = "SELECT * FROM Users ORDER BY name ASC";
            SqliteCommand command = db.DoSql(sqlExpression);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var name = reader.GetValue(0);
                        comboBox1.Items.Add(name);
                    }
                }
            }
            db.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnect db = DBconnect.getDataBase();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            string sqlExpression = $"SELECT * FROM Users where name='{comboBox1.SelectedItem}'";
            SqliteCommand command = db.DoSql(sqlExpression);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                string name = (reader.GetValue(0)).ToString();
                DateTime date = Convert.ToDateTime(reader.GetValue(1));
                Form1.SelfRef.birthday = new Person(date, name);
                Form1.SelfRef.PersonCalc(Form1.SelfRef.birthday);
                Form1.SelfRef.ChangeTab_Person(date);
                Close();
            }
            db.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBconnect db = DBconnect.getDataBase();
            string sqlExpression = $"DELETE FROM Users where name='{comboBox1.SelectedItem}'";
            SqliteCommand command = db.DoSql(sqlExpression);
            command.ExecuteNonQuery();
            db.Close();
            Close();
            Form_UserOpen newForm = new Form_UserOpen();
            newForm.Show();
        }
    }
}
