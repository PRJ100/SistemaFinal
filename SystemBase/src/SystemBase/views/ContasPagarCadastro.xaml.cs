using ModeloDeDados.Classes;
using ModeloDeDados.Dados;
using System;
using System.Windows;

namespace SystemBase.views
{
    /// <summary>
    /// Lógica interna para ContasPagarCadastro.xaml
    /// </summary>
    public partial class ContasPagarCadastro : Window
    {
        private string op = "";
        public ContasPagarCadastro()
        {
            InitializeComponent();
            op = "";
        }
        public ContasPagarCadastro(ContasPagar cp)
        {
            InitializeComponent();
            op = "alterar";
            tbCodigo.Text = cp.ContasPagarId.ToString();
            tbCNPJ_CPF.Text = cp.CNPJ_CPF;
            tbDescricao.Text = cp.Descricao;
            dpVencimento.Text = cp.Vencimento.ToString();
            cbFormaPagamento.Text = cp.FormaPagamento;
            tbContato.Text = cp.Contato;
            tbValor.Text = cp.Valor.ToString();

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ContasPagar cp = new ContasPagar();
            cp.CNPJ_CPF = tbCNPJ_CPF.Text;
            cp.Descricao = tbDescricao.Text;
            cp.Vencimento = dpVencimento.SelectedDate.Value;
            cp.FormaPagamento = cbFormaPagamento.Text;
            cp.Contato = tbContato.Text;
            cp.Valor = Convert.ToDecimal(tbValor.Text);

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    cp = ctx.ContasPagar.Find(Convert.ToInt32(tbCodigo.Text));
                    if (cp != null)
                    {
                        cp.CNPJ_CPF = tbCNPJ_CPF.Text;
                        cp.Descricao = tbDescricao.Text;
                        cp.Vencimento = dpVencimento.SelectedDate.Value;
                        cp.FormaPagamento = cbFormaPagamento.Text;
                        cp.Contato = tbContato.Text;
                        cp.Valor = Convert.ToDecimal(tbValor.Text);
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.ContasPagar.Add(cp);
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
