using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Net;

namespace Catalog
{
    public partial class Form1 : Form
    {

        private MySqlConnection conn;
        private string connStr = "server=localhost;user=root;database=catalog_db;port=3306;password=admin;";
        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection(connStr);
            groupBox1.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cauta_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Audi")
            {
                listBox2.Items.Clear();
                string audi = @"C:\Users\octav\Desktop\II_lab\Tema_alegere\Catalog\audi.txt";
                string[] lista = File.ReadAllLines(audi);
                foreach (string s in lista)
                {
                    listBox2.Items.Add(s);
                }

            }
            else if (textBox1.Text == "BMW")
            {
                listBox2.Items.Clear();
                string bmw = @"C:\Users\octav\Desktop\II_lab\Tema_alegere\Catalog\bmw.txt";
                string[] lista = File.ReadAllLines(bmw);
                foreach (string s in lista)
                {
                    listBox2.Items.Add(s);
                }
            }
            else if (textBox1.Text == "Ford")
            {
                listBox2.Items.Clear();
                string ford = @"C:\Users\octav\Desktop\II_lab\Tema_alegere\Catalog\ford.txt";
                string[] lista = File.ReadAllLines(ford);
                foreach (string s in lista)
                {
                    listBox2.Items.Add(s);
                }
            }
            else if (textBox1.Text == "Volkswagen")
            {
                listBox2.Items.Clear();
                string vv = @"C:\Users\octav\Desktop\II_lab\Tema_alegere\Catalog\VV.txt";
                string[] lista = File.ReadAllLines(vv);
                foreach (string s in lista)
                {
                    listBox2.Items.Add(s);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            string selectedModel = listBox2.SelectedItem.ToString();
            try
            {
                conn.Open();

                string sql = "SELECT * FROM masini WHERE model = @Model";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Model", selectedModel);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nume.Text = reader["Nume"].ToString();
                    model.Text = reader["Model"].ToString();
                    an_f.Text = reader["an_f"].ToString();
                    pret.Text = reader["Pret"].ToString();
                    descriere.Text = reader["Descriere"].ToString();
                    label5.Text = reader["moneda"].ToString();
                    string poza = reader["poza"].ToString();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.ImageLocation = poza;

                   

                }
                else
                {
                    MessageBox.Show("Modelul selectat nu a fost găsit în baza de date.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

       private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Creazacont cont = new Creazacont();
            cont.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();  
            login.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
  
            if (Classuser.userlogat == 0)
            {
                
                                    
                    MessageBox.Show("Trebuie să te loghezi");
                
            }
            else
            {
                Gestiune gest = new Gestiune();
                gest.Show();
            }

        }
    }
}