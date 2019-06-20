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
    /// Lógica interna para ContasPagarCadastroView.xaml
    /// </summary>
    public partial class ContasPagarCadastroView : Window
    {
        public ContasPagarCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovaContaPagar_Click(object sender, RoutedEventArgs e)
        {
            new ContasPagarCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void DgMostraContasPagar_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirContasPagar_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraContasPagar.SelectedIndex >= 0)
            {
                ContasPagar cp = (ContasPagar)dgMostraContasPagar.Items[dgMostraContasPagar.SelectedIndex];
                using (DBContexto ctx = new DBContexto())
                {
                    cp = ctx.ContasPagar.Find(cp.ContasPagarId);
                    ctx.ContasPagar.Remove(cp);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarContasPagar_Click(object sender, RoutedEventArgs e)
        {
            ContasPagar cp = new ContasPagar();
            if (dgMostraContasPagar.SelectedIndex >= 0)
            {
                cp = (ContasPagar)dgMostraContasPagar.Items[dgMostraContasPagar.SelectedIndex];

                new ContasPagarCadastro(cp).Show();
            }
        }

        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.ContasPagar;
                dgMostraContasPagar.ItemsSource = consulta.ToList();

            }
        }

        private void BtnPesquisaContasPagar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var consulta = from c in ctx.ContasPagar where c.Descricao.Contains(tbPesquisa.Text)
                                   select c;
                    dgMostraContasPagar.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }
    }
}
