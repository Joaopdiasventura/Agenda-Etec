using MySql.Data.MySqlClient;
using ProjetoAgendaContatos.src.dtos;
using ProjetoAgendaContatos.src.services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoAgendaContatos.src.pages
{
    public partial class Change : Form
    {
        Conection c = new Conection();
        public Change()
        {
            InitializeComponent();
        }

        private void Change_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM tbcontato;";
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                c.Conect();
                List<Contact> contacts = new List<Contact>();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact();
                        contact.Codcontato = reader.GetInt32("codcontato");
                        contact.Nome = reader.GetString("nome");
                        contact.Telefone = reader.GetString("telefone");
                        contact.Celular = reader.GetString("celular");
                        contact.Email = reader.GetString("email");
                        contacts.Add(contact);
                    }
                }

                c.Disconnect();
                dataGridView1.Rows.Clear();
                foreach (Contact contact in contacts)
                {
                    dataGridView1.Rows.Add(contact.Nome, contact.Telefone, contact.Telefone, contact.Email, contact.Codcontato);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 nw = new Form1();
            nw.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            object idCellValue = dataGridView1.Rows[rowIndex].Cells["cod"].Value;
            string sql = "DELETE FROM tbcontato WHERE codcontato = " + idCellValue + ";";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.Conect();
            cmd.ExecuteNonQuery();
            c.Disconnect();
            Change nw = new Change();
            nw.Show();
            Hide();
        }
    }
}
