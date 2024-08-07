﻿using MySql.Data.MySqlClient;
using ProjetoAgendaContatos.src.dtos;
using ProjetoAgendaContatos.src.services;
using System;
using System.Windows.Forms;

namespace ProjetoAgendaContatos.src.pages
{
    public partial class Register : Form
    {
        Conection c = new Conection();
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String Nome = maskedTextBox1.Text;
            String Telefone = maskedTextBox2.Text;
            String Celular = maskedTextBox3.Text;
            String Email = maskedTextBox4.Text;
            Contact con = new Contact();
            con.Nome = Nome;
            con.Telefone = Telefone;
            con.Celular = Celular;  
            con.Email = Email;
            MessageBox.Show(RegisterUser(con));
        }
        public string RegisterUser(Contact cont)
        {
            try
            {
                string sql = "INSERT INTO tbcontato (nome, telefone, celular, email) " +
                "VALUES (' " + cont.Nome + "', '" + cont.Telefone + "', " +
                "'" + cont.Celular + "', '" + cont.Email + "')";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                c.Conect();
                cmd.ExecuteNonQuery();
                c.Disconnect();
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
                maskedTextBox3.Text = "";
                maskedTextBox4.Text = "";
                return ("Contato cadastrado com sucesso.");
            }

            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 nw = new Form1();
            nw.Show();
            Hide();
        }
    }
}
