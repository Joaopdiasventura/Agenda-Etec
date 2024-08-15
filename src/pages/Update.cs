using MySql.Data.MySqlClient;
using ProjetoAgendaContatos.src.services;
using ProjetoAgendaContatos.src.statics;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjetoAgendaContatos.src.pages
{
    public partial class Update : Form
    {
        Conection c = new Conection();
        public Update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = ChangingContact.nome;
            maskedTextBox2.Text = ChangingContact.telefone;
            maskedTextBox3.Text = ChangingContact.celular;
            maskedTextBox4.Text = ChangingContact.email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE tbcontato SET " +
             $"nome = '{maskedTextBox1.Text}', " +
             $"telefone = '{maskedTextBox2.Text}', " +
             $"celular = '{maskedTextBox3.Text}', " +
             $"email = '{maskedTextBox4.Text}' " +
             $"WHERE codcontato = {ChangingContact.codContato}";
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            c.Conect();
            cmd.ExecuteNonQuery();
            c.Disconnect();
            Read nw = new Read();
            nw.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Read nw = new Read();
            nw.Show();
            Hide();
        }
    }
}
