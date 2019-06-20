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
    /// Lógica interna para PlanoCadastroView.xaml
    /// </summary>
    public partial class PlanoCadastroView : Window
    {
        public PlanoCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoPlano_Click(object sender, RoutedEventArgs e)
        {
            new PlanoCadastro().Show();
        }

        private void BtnVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirPlano_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraPlanos.SelectedIndex >= 0)
            {
                Plano p = (Plano)dgMostraPlanos.Items[dgMostraPlanos.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    p = ctx.Planos.Find(p.PlanoId);
                    ctx.Planos.Remove(p);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarPlano_Click(object sender, RoutedEventArgs e)
        {
            Plano p = new Plano();
            if (dgMostraPlanos.SelectedIndex >= 0)
            {
                p = (Plano)dgMostraPlanos.Items[dgMostraPlanos.SelectedIndex];

                new PlanoCadastro(p).Show();

            }
        }

        private void DgMostraPlanos_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Planos;
                dgMostraPlanos.ItemsSource = consulta.ToList();
            }
        }

        private void BtnPesquisaPlano_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var consulta = from c in ctx.Planos
                                   where c.Nome.Contains(tbPesquisa.Text)
                                   select c;
                    dgMostraPlanos.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }
    }
}
