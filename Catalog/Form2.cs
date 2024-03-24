using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace Catalog
{
    public partial class Form2 : Form
    {
        MySqlConnection conection = new MySqlConnection("server=localhost;user=root;database=catalog_db;port=3306;password=admin;");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string add = "INSERT INTO masini(nume, pret, an_f, descriere, locatie, model, moneda, poza) VALUES('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox7.Text + "')";
            conection.Open();
            MySqlCommand command = new MySqlCommand(add, conection);
            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Anunt adaugat cu succes");
            }
            else
            {
                MessageBox.Show("Ceva nu a functionat corect");
            }
            conection.Close();

        }
    }
}
