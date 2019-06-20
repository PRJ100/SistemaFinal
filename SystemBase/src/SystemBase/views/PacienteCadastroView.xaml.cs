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
    /// Lógica interna para PacienteCadastroView.xaml
    /// </summary>
    public partial class PacienteCadastroView : Window
    {
        public PacienteCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoPaciente_Click(object sender, RoutedEventArgs e)
        {
            new PacienteCadastro().Show();
        }


        private void DgMostraPaciente_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnExcluirPaciente_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraPaciente.SelectedIndex >= 0)
            {
                Pessoa p = (Pessoa)dgMostraPaciente.Items[dgMostraPaciente.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    p = ctx.Pessoas.Find(p.PessoaId);
                    ctx.Pessoas.Remove(p);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarPaciente_Click(object sender, RoutedEventArgs e)
        {
            Pessoa p = new Pessoa();
            if (dgMostraPaciente.SelectedIndex >= 0)
            {
                p = (Pessoa)dgMostraPaciente.Items[dgMostraPaciente.SelectedIndex];

                new PacienteCadastro(p).Show();

            }
        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Pessoas
                    .Include(c => c.Cidade);
                dgMostraPaciente.ItemsSource = consulta.ToList();
            }
        }

        private void BtnPesquisaPaciente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var consulta = from c in ctx.Pessoas
                                   .Include(c => c.Cidade)
                                   where c.Nome.Contains(tbPesquisar.Text)|| c.Contato.Contains(tbPesquisar.Text) || c.CPF.Contains(tbPesquisar.Text)|| c.RG.Contains(tbPesquisar.Text)
                                   select c;
                    dgMostraPaciente.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }
    }
}
