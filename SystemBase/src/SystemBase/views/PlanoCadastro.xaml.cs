using ModeloDeDados.Classes;
using ModeloDeDados.Dados;
using System;
using System.Windows;


namespace SystemBase.views
{
    /// <summary>
    /// Lógica interna para PlanoCadastro.xaml
    /// </summary>
    public partial class PlanoCadastro : Window
    {
        private string op = "";

        public PlanoCadastro()
        {
            InitializeComponent();
            op = "";
        }
        public PlanoCadastro(Plano p)
        {
            InitializeComponent();
            op = "alterar";
            tbCodigo.Text = p.PlanoId.ToString();
            tbNome.Text = p.Nome;
            tbNumero.Text = p.Numero;
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Plano p = new Plano();

            p.Nome = tbNome.Text;
            p.Numero = tbNumero.Text;

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    p = ctx.Planos.Find(Convert.ToInt32(tbCodigo.Text));
                    if (p != null)
                    {
                        p.Nome = tbNome.Text;
                        p.Numero = tbNumero.Text;
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Planos.Add(p);
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
