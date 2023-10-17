using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Astro;
using Microsoft.Data.Sqlite;

namespace WindowsFormsAppTest
{
    public partial class Form_CelebrityAdd : Form
    {
        public Form_CelebrityAdd()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label5.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AstroObject birthday = new AstroObject(dateTimePicker1.Value);
            try
            {
                DBconnect db = DBconnect.getDataBase();
                string sqlExpression = $"INSERT INTO Celebrities (name, birthday, profession, sun, moon, mercury_helio, mercury_geo, venus_helio, venus_geo, mars_helio, mars_geo, " +
                    $"jupiter_helio, jupiter_geo, saturn_helio, saturn_geo, uranus_helio, uranus_geo, neptune_helio, neptune_geo, pluto_helio, pluto_geo, sun_chertog, moon_chertog, " +
                    $"mercury_helio_chertog, mercury_geo_chertog, venus_helio_chertog, venus_geo_chertog, mars_helio_chertog, mars_geo_chertog, jupiter_helio_chertog, jupiter_geo_chertog, " +
                    $"saturn_helio_chertog, saturn_geo_chertog, uranus_helio_chertog, uranus_geo_chertog, neptune_helio_chertog, neptune_geo_chertog, pluto_helio_chertog, pluto_geo_chertog) VALUES " +
                    $"('{textBox1.Text}', '{dateTimePicker1.Value}', '{textBox2.Text}', {birthday.coords.sun}, {birthday.coords.moon}, {birthday.coords.mercury.helio}, {birthday.coords.mercury.geo}, " +
                    $"{birthday.coords.venus.helio}, {birthday.coords.venus.geo}, {birthday.coords.mars.helio}, {birthday.coords.mars.geo}, " +
                    $"{birthday.coords.jupiter.helio}, {birthday.coords.jupiter.geo}, {birthday.coords.saturn.helio}, {birthday.coords.saturn.geo}, " +
                    $"{birthday.coords.uranus.helio}, {birthday.coords.uranus.geo}, {birthday.coords.neptune.helio}, {birthday.coords.neptune.geo}, " +
                    $"{birthday.coords.pluto.helio}, {birthday.coords.pluto.geo}, " +
                    $"'{birthday.sun.helio.chertog.name}', '{birthday.moon.helio.chertog.name}', '{birthday.mercury.helio.chertog.name}', '{birthday.mercury.geo.chertog.name}', " +
                    $"'{birthday.venus.helio.chertog.name}', '{birthday.venus.geo.chertog.name}', '{birthday.mars.helio.chertog.name}', '{birthday.mars.geo.chertog.name}', " +
                    $"'{birthday.jupiter.helio.chertog.name}', '{birthday.jupiter.geo.chertog.name}', '{birthday.saturn.helio.chertog.name}', '{birthday.saturn.geo.chertog.name}', " +
                    $"'{birthday.uranus.helio.chertog.name}', '{birthday.uranus.geo.chertog.name}', '{birthday.neptune.helio.chertog.name}', '{birthday.neptune.geo.chertog.name}', " +
                    $"'{birthday.pluto.helio.chertog.name}', '{birthday.pluto.geo.chertog.name}')";
                SqliteCommand command = db.DoSql(sqlExpression);
                command.ExecuteNonQuery();
                label5.Text += "Данные " + textBox1.Text + " успешно сохранены!";
                db.Close();
            }
            catch
            {
                MessageBox.Show("Такое имя уже находится в базе данных! Нужно ввести другое имя!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form_CelebrityAdd newForm = new Form_CelebrityAdd();
            newForm.Show();
        }
    }
}
