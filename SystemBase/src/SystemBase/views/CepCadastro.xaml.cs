using ModeloDeDados.Dados;
using ModeloDeDados.Classes;
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
    /// Lógica interna para CepCadastro.xaml
    /// </summary>
    public partial class CepCadastro : Window
    {
        private string op = "";
        private List<Cidade> Cidades;
        public CepCadastro()
        {
            InitializeComponent();
            PreencheComboBox();
            op = "";
        }
        public CepCadastro(Cep c)
        {
            InitializeComponent();
            PreencheComboBox();
            op = "alterar";

            tbCodigo.Text = c.CepId.ToString();
            tbNumeroCep.Text = c.NumeroCep;
            cbCodigoCidade.SelectedValue = c.CidadeId;

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Cep c = new Cep();
            c.NumeroCep = tbNumeroCep.Text;
            c.CidadeId = Convert.ToInt32(cbCodigoCidade.SelectedValue);
            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    c = ctx.Ceps.Find(Convert.ToInt32(tbCodigo.Text));
                    if (c != null)
                    {

                        c.NumeroCep = tbNumeroCep.Text;
                        c.CidadeId = Convert.ToInt32(cbCodigoCidade.SelectedValue);
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Ceps.Add(c);
                    ctx.SaveChanges();
                }
            }

            this.Close();

        }


        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void PreencheComboBox()
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var item = ctx.Cidades.ToList();
                    Cidades = item;

                    cbCodigoCidade.DataContext = Cidades;
                }
            }
            catch { }
        }

    }
}
