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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Catalog
{
    public partial class Login : Form
    {
        MySqlConnection conection = new MySqlConnection("server=localhost;user=root;database=catalog_db;port=3306;password=admin;");
        public Login()
        {
            InitializeComponent();
            label3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            conection.Open();
            string log = "SELECT email, parola FROM users WHERE email = '" + textBox1.Text + "' AND parola = '" + textBox2.Text + "'";
            var cmd = new MySqlCommand(log, conection);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);    
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if(i == 0 )
            {
                label3.BackColor = Color.Red;
                label3.Text = "Emailul sau parola sunt gresite";
                label3.Show();
            }
            else
            {
                label3.BackColor = Color.Green;
                label3.Text = "Logarea s-a facut cu succes";
                label3.Show();
                string user = "SELECT id FROM users WHERE email = '" + textBox1.Text + "'";
                var cmduser = new MySqlCommand(user,conection);
                object result = cmduser.ExecuteScalar();
                Classuser.userlogat = Convert.ToInt32(result);
            }
            conection.Close();
            }
        }
    }

