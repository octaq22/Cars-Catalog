using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Catalog
{
    public partial class Creazacont : Form
    {
        MySqlConnection conection = new MySqlConnection("server=localhost;user=root;database=catalog_db;port=3306;password=admin;");
        public Creazacont()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string add = "INSERT INTO users(email, parola) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";

            conection.Open();
            MySqlCommand command = new MySqlCommand(add, conection);
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Contul a fost creeat cu succes");
            }
            else
            {
                MessageBox.Show("Ceva nu a functionat corect");
            }
            conection.Close();
        }
    }
}
