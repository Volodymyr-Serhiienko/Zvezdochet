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

namespace WindowsFormsAppTest
{
    public partial class Form_UserAdd : Form
    {
        public Form_UserAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = dateTimePicker1.Value;
                using (var connection = new SqliteConnection("Data Source=AstroDB.db"))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = $"INSERT INTO Users (name, birthday) VALUES ('{textBox1.Text}', '{date}')";
                    command.ExecuteNonQuery();
                }
                label5.Text += "Данные " + textBox1.Text + " успешно сохранены!";
            }
            catch
            {
                MessageBox.Show("Такое имя пользователя уже находится в базе данных! Нужно ввести другое имя!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form_UserAdd newForm = new Form_UserAdd();
            newForm.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label5.Text = null;
        }
    }
}
