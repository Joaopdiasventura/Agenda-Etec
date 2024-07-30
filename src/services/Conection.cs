using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetoAgendaContatos.src.services
{
    internal class Conection
    {
        public MySqlConnection con = new MySqlConnection(@"server=localhost;port=3306;Database=agenda;User=root;Pwd=");

        public string Conect()
        {
            try
            {
                con.Open();
                return "Conexão realizada com sucesso";
            }
            catch (MySqlException e)
            {
                return e.ToString();
            }
        }

        public string Disconnect()
        {
            try
            {
                con.Close();
                return "Conexão encerrada com sucesso";
            }
            catch (MySqlException e)
            {
                return e.ToString();
            }
        }

    }
    
}
