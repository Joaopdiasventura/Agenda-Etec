using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgendaContatos.src.pages
{
    public partial class Changing : Form
    {
        int cod;
        public Changing(int Cod)
        {
            InitializeComponent();
            cod = Cod;
        }

        private void Changing_Load(object sender, EventArgs e)
        {

        }
    }
}
