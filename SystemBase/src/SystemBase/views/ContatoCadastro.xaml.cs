using ModeloDeDados.Classes;
using ModeloDeDados.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemBase.views
{
    /// <summary>
    /// Lógica interna para ContatoCadastro.xaml
    /// </summary>
    public partial class ContatoCadastro : Window
    {

        private string op = "";
        public ContatoCadastro()
        {
            InitializeComponent();
            op = "";
        }
        public ContatoCadastro(Cotato c)
        {
            InitializeComponent();
            op = "alterar";
            tbCodigo.Text = c.ContatoId.ToString();
            tbNome.Text = c.Nome;
            tbNumero.Text = c.Numero;
            cbTipo.Text = c.Tipo;
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Cotato c = new Cotato();

            c.Nome = tbNome.Text;
            c.Numero = tbNumero.Text;
            c.Tipo = cbTipo.Text;

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    c = ctx.Contatos.Find(Convert.ToInt32(tbCodigo.Text));
                    if (c != null)
                    {
                        c.Nome = tbNome.Text;
                        c.Numero = tbNumero.Text;
                        c.Tipo = cbTipo.Text;
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Contatos.Add(c);
                    ctx.SaveChanges();
                }
            }

            this.Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
