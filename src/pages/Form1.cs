using MySql.Data.MySqlClient;
using ProjetoAgendaContatos.src.pages;
using ProjetoAgendaContatos.src.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgendaContatos
{
    public partial class Form1 : Form
    {
        Conection c = new Conection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair?", "Saindo da aplicação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register nw = new Register();
            nw.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Change nw = new Change();
            nw.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Backup("../../Backup"), "Backup do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string Backup(string caminho)
        {
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string caminhoBackup = Path.Combine(caminho, "backupContatos_" + dataAtual + ".sql");

            string diretórioBackup = Path.GetDirectoryName(caminhoBackup);
            if (!Directory.Exists(diretórioBackup))
            {
                Directory.CreateDirectory(diretórioBackup);
            }

            string connectionString = "Server=localhost;Database=agenda;Uid=root;Pwd=;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;

                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            mb.ExportToFile(caminhoBackup);
                        }
                    }

                    conn.Close();
                }

                return "Backup do banco de dados realizado com sucesso!";
            }
            catch (MySqlException e)
            {
                return e.ToString();
            }
        }
    }
}
