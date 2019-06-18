using ModeloDeDados.Classes;
using ModeloDeDados.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace SystemBase.views
{
    /// <summary>
    /// Lógica interna para EstadoCadastro.xaml
    /// </summary>
    public partial class EstadoCadastro : Window
    {
        private string op = "";
        private List<Pais> paises;

        public EstadoCadastro()
        {
            InitializeComponent();
            PreencheComboBox();
            op = "";
        }
        public EstadoCadastro(Estado es)
        {
            InitializeComponent();
            PreencheComboBox();
            op = "alterar";
            tbCodigo.Text = es.EstadoId.ToString();
            tbNome.Text = es.Nome;
            tbSigla.Text = es.Sigla;
            tbCodigoIBGE.Text = es.CodigoIBGE.ToString();
            cbCodigoPais.SelectedValue = es.PaisId;
        }



        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Estado es = new Estado();

            es.Nome = tbNome.Text;
            es.Sigla = tbSigla.Text;
            es.CodigoIBGE = Convert.ToInt32(tbCodigoIBGE.Text);
            es.PaisId = Convert.ToInt32(cbCodigoPais.SelectedValue);

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    es = ctx.Estados.Find(Convert.ToInt32(tbCodigo.Text));
                    if (es != null)
                    {
                        es.Nome = tbNome.Text;
                        es.Sigla = tbSigla.Text;
                        es.CodigoIBGE = Convert.ToInt32(tbCodigoIBGE.Text);
                        es.PaisId = Convert.ToInt32(cbCodigoPais.SelectedValue);
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Estados.Add(es);
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
                    var item = ctx.Paises.ToList();
                    paises = item;

                    cbCodigoPais.DataContext = paises;
                }
            }
            catch { }
        }
    }
}

