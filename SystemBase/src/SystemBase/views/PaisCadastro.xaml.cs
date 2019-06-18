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
    /// Lógica interna para PaisCadastro.xaml
    /// </summary>
    public partial class PaisCadastro : Window
    {
        private string op = "";
        public PaisCadastro()
        {
            InitializeComponent();
            op = "";
        }
        public PaisCadastro(Pais p)
        {
            InitializeComponent();
            op = "alterar";
            tbCodigo.Text = p.PaisId.ToString();
            tbNome.Text = p.Nome;
            tbCodigoArea.Text = p.CodigoTelefone.ToString();
            
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Pais p = new Pais();

            p.Nome = tbNome.Text;
            p.CodigoTelefone = Convert.ToInt32(tbCodigoArea.Text);

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    p = ctx.Paises.Find(Convert.ToInt32(tbCodigo.Text));
                    if (p != null)
                    {
                        p.Nome = tbNome.Text;
                        p.CodigoTelefone = Convert.ToInt32(tbCodigoArea.Text);
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Paises.Add(p);
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
