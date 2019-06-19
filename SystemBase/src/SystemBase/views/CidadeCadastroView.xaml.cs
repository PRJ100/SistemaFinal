using Microsoft.EntityFrameworkCore;
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
    /// Lógica interna para CidadeCadastroView.xaml
    /// </summary>
    public partial class CidadeCadastroView : Window
    {
        public CidadeCadastroView()
        {
            InitializeComponent();

        }

        private void BtnNovoCidade_Click(object sender, RoutedEventArgs e)
        {
            new CidadeCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void DgMostraCidade_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirCidade_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraCidade.SelectedIndex >= 0)
            {
                Cidade ci = (Cidade)dgMostraCidade.Items[dgMostraCidade.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    ci = ctx.Cidades.Find(ci.CidadeId);
                    ctx.Cidades.Remove(ci);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }



        private void BtnAlterarCidade_Click(object sender, RoutedEventArgs e)
        {
            Cidade ci = new Cidade();
            if (dgMostraCidade.SelectedIndex >= 0)
            {
                ci = (Cidade)dgMostraCidade.Items[dgMostraCidade.SelectedIndex];

                new CidadeCadastro(ci).Show();
            }
        }

        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Cidades
                    .Include(e => e.Estado)
                    .Include(c => c.Ceps);
                dgMostraCidade.ItemsSource = consulta.ToList();

            }
        }
    }
}
