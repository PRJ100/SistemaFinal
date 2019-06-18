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
    /// Lógica interna para CidadeCadastro.xaml
    /// </summary>
    public partial class CidadeCadastro : Window
    {
        private string op = "";
        private List<Estado> Estados;



        public CidadeCadastro()
        {

            InitializeComponent();
            PreencheComboBox();
            op = "";
        }
        public CidadeCadastro(Cidade ci)
        {
            InitializeComponent();
            PreencheComboBox();
            op = "alterar";
            tbCodigo.Text = ci.CidadeId.ToString();
            tbNome.Text = ci.Nome;
            tbCodigoIBGE.Text = ci.CodigoIBGE.ToString();
            cbCodigoEstado.SelectedValue = ci.EstadoId;
            
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Cidade ci = new Cidade();
            ci.Nome = tbNome.Text;
            ci.CodigoIBGE = Convert.ToInt32(tbCodigoIBGE.Text);
            ci.EstadoId = Convert.ToInt32(cbCodigoEstado.SelectedValue);
            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    ci = ctx.Cidades.Find(Convert.ToInt32(tbCodigo.Text));
                    if (ci != null)
                    {

                        ci.Nome = tbNome.Text;
                        ci.CodigoIBGE = Convert.ToInt32(tbCodigoIBGE.Text);
                        ci.EstadoId = Convert.ToInt32(cbCodigoEstado.SelectedValue);
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Cidades.Add(ci);
                    ctx.SaveChanges();
                }
            }

            this.Close();

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void PreencheComboBox()
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var item = ctx.Estados.ToList();
                    Estados = item;

                    cbCodigoEstado.DataContext = Estados;
                }
            }
            catch { }
        }
    }
}
