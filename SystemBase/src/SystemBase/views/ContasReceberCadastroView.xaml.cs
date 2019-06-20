﻿using ModeloDeDados.Dados;
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
    /// Lógica interna para ContasReceberCadastroView.xaml
    /// </summary>
    public partial class ContasReceberCadastroView : Window
    {
        public ContasReceberCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoContasReceber_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void DgMostraContasReber_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcluirContasReceber_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAlterarContasReceber_Click(object sender, RoutedEventArgs e)
        {

        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.ContasReceber;
                   
                dgMostraContasReceber.ItemsSource = consulta.ToList();

            }
        }

        private void BtnPesquisaContasReceber_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var consulta = from c in ctx.ContasReceber
                                   where c.Descricao.Contains(tbPesquisa.Text)
                                   select c;
                    dgMostraContasReceber.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }
    }
}
