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
    /// Lógica interna para CepCadastroView.xaml
    /// </summary>
    public partial class CepCadastroView : Window
    {
        public CepCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoCep_Click(object sender, RoutedEventArgs e)
        {
            new CepCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void DgMostraCep_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirCep_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraCep.SelectedIndex >= 0)
            {
                Cep c = (Cep)dgMostraCep.Items[dgMostraCep.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    c = ctx.Ceps.Find(c.CepId);
                    ctx.Ceps.Remove(c);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarCep_Click(object sender, RoutedEventArgs e)
        {
            Cep c = new Cep();
            if (dgMostraCep.SelectedIndex >= 0)
            {
                c = (Cep)dgMostraCep.Items[dgMostraCep.SelectedIndex];

                new CepCadastro(c).Show();
            }
        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Ceps;
                dgMostraCep.ItemsSource = consulta.ToList();

            }
        }
    }
}
