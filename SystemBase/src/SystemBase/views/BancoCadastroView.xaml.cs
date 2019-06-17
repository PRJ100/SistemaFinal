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
    /// Lógica interna para BancoCadastroView.xaml
    /// </summary>
    public partial class BancoCadastroView : Window
    {
        public BancoCadastroView()
        {
            InitializeComponent();
        }
        private void BtnNovoBanco_Click(object sender, RoutedEventArgs e)
        {
            new BancoCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void DgMostraBanco_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirBanco_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraBanco.SelectedIndex >= 0)
            {
                Banco b = (Banco)dgMostraBanco.Items[dgMostraBanco.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    b = ctx.Bancos.Find(b.BancoId);
                    ctx.Bancos.Remove(b);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarBanco_Click(object sender, RoutedEventArgs e)
        {
            Banco b = new Banco();
            if (dgMostraBanco.SelectedIndex >= 0)
            {
                b = (Banco)dgMostraBanco.Items[dgMostraBanco.SelectedIndex];

                new BancoCadastro(b).Show();

            }
        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Bancos;
                dgMostraBanco.ItemsSource = consulta.ToList();
            }
        }
    }
}
