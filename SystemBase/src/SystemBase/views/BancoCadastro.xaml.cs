using ModeloDeDados.Classes;
using ModeloDeDados.Dados;
using System;
using System.Windows;


namespace SystemBase.views
{
    /// <summary>
    /// Lógica interna para BancoCadastro.xaml
    /// </summary>
    public partial class BancoCadastro : Window
    {
        private string op = "";
        public BancoCadastro()
        {
            InitializeComponent();
            op = "";
        }
        public BancoCadastro(Banco b)
        {
            InitializeComponent();
            op = "alterar";
            tbCodigo.Text = b.BancoId.ToString();
            tbCodigoBanco.Text = b.Codigo.ToString();
            tbNome.Text = b.Nome;
            

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Banco b = new Banco();

            b.Nome = tbNome.Text;
            b.Codigo = Convert.ToInt32(tbCodigoBanco.Text);

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    b = ctx.Bancos.Find(Convert.ToInt32(tbCodigo.Text));
                    if (b != null)
                    {
                        b.Nome = tbNome.Text;
                        b.Codigo = Convert.ToInt32(tbCodigoBanco.Text);
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Bancos.Add(b);
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
