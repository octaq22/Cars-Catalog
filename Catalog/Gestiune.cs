using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalog
{
    public partial class Gestiune : Form
    {
        private DataTable dataTable;
        private MySqlConnection conn;
        private string connStr = "server=localhost;user=root;database=catalog_db;port=3306;password=admin;";
        public Gestiune()
        {
            InitializeComponent();
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM masini WHERE iduser = '" + Classuser.userlogat + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();

        }
        private void UpdateSelectedRow()
        {
            conn.Open();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    
                    MySqlCommand command = new MySqlCommand("UPDATE masini SET nume = @nume, pret = @pret, an_f = @an_f, descriere = @descriere, locatie = @locatie, model = @model, moneda = @moneda, poza = @poza WHERE idmasini = @idmasini", conn);
                    command.Parameters.AddWithValue("@nume", dataGridView1.Rows[i].Cells[1].Value);
                    command.Parameters.AddWithValue("@pret", dataGridView1.Rows[i].Cells[2].Value);
                    command.Parameters.AddWithValue("@an_f", dataGridView1.Rows[i].Cells[3].Value);
                    command.Parameters.AddWithValue("@descriere", dataGridView1.Rows[i].Cells[4].Value);
                    command.Parameters.AddWithValue("@locatie", dataGridView1.Rows[i].Cells[5].Value);
                    command.Parameters.AddWithValue("@model", dataGridView1.Rows[i].Cells[6].Value);
                    command.Parameters.AddWithValue("@moneda", dataGridView1.Rows[i].Cells[7].Value);
                    command.Parameters.AddWithValue("@poza", dataGridView1.Rows[i].Cells[8].Value);
                    command.Parameters.AddWithValue("@idmasini", dataGridView1.Rows[i].Cells[0].Value);
                    command.ExecuteNonQuery();
                    
                }
                MessageBox.Show("Anuntul selectat a fost actualizat.");
            conn.Close();

        }
        private void RefreshData()
        {
            conn.Open();
            string sql = "SELECT * FROM masini WHERE iduser = '" + Classuser.userlogat + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            conn.Close();
        }
        private void DeleteSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                string idmasini = dataGridView1.Rows[selectedIndex].Cells["idmasini"].Value.ToString();

                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM masini WHERE idmasini = @idmasini", conn);
                command.Parameters.AddWithValue("@idmasini", idmasini);
                command.ExecuteNonQuery();
                conn.Close();

                RefreshData(); 
                MessageBox.Show("Anuntul selectat a fost sters.");
            }
            else
            {
                MessageBox.Show("Selectati un rând pentru a sterge.");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
           UpdateSelectedRow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }
    }

    }

