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
    /// Lógica interna para ContasReceberCadastro.xaml
    /// </summary>
    public partial class ContasReceberCadastro : Window
    {
        private string op = "";
        public ContasReceberCadastro()
        {
            InitializeComponent();
             op = "";
        }
        public ContasReceberCadastro(ContasReceber cr)
        {
            InitializeComponent();
            op = "alterar";
            tbCodigo.Text = cr.ContasReceberId.ToString();
            tbCNPJ_CPF.Text = cr.CNPJ_CPF;
            tbDescricao.Text = cr.Descricao;
            dpVencimento.Text = cr.Vencimento.ToString();
            cbFormaPagamento.Text = cr.FormaPagamento;
            tbContato.Text = cr.Contato;
            tbValor.Text = cr.Valor.ToString();

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            ContasReceber cr = new ContasReceber();
            cr.CNPJ_CPF = tbCNPJ_CPF.Text;
            cr.Descricao = tbDescricao.Text;
            cr.Vencimento = dpVencimento.SelectedDate.Value;
            cr.FormaPagamento = cbFormaPagamento.Text;
            cr.Contato = tbContato.Text;
            cr.Valor = Convert.ToDecimal(tbValor.Text);

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    cr = ctx.ContasReceber.Find(Convert.ToInt32(tbCodigo.Text));
                    if (cr != null)
                    {
                        cr.CNPJ_CPF = tbCNPJ_CPF.Text;
                        cr.Descricao = tbDescricao.Text;
                        cr.Vencimento = dpVencimento.SelectedDate.Value;
                        cr.FormaPagamento = cbFormaPagamento.Text;
                        cr.Contato = tbContato.Text;
                        cr.Valor = Convert.ToDecimal(tbValor.Text);
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.ContasReceber.Add(cr);
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
