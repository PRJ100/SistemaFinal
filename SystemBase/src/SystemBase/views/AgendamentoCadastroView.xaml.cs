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
    /// Lógica interna para AgendamentoCadastroView.xaml
    /// </summary>
    public partial class AgendamentoCadastroView : Window
    {
        public AgendamentoCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoAgendamento_Click(object sender, RoutedEventArgs e)
        {
            new AgendamentoCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnPesquisaAgendamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var consulta = from a in ctx.Agendamentos
                        .Include(a => a.Pessoa)
                        .Include(a => a.Medico)
                        .Include(a => a.Plano)
                                   where a.HorarioConsuta.Contains(tbPesquisa.Text)
                                   select a;
                    dgMostraAgendamentos.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }

        private void DgMostraAgendamentos_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirAgendamento_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraAgendamentos.SelectedIndex >= 0)
            {
                Agendamento a = (Agendamento)dgMostraAgendamentos.Items[dgMostraAgendamentos.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    a = ctx.Agendamentos.Find(a.AgendamentoId);
                    ctx.Agendamentos.Remove(a);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarAgendamento_Click(object sender, RoutedEventArgs e)
        {
            Agendamento a = new Agendamento();
            if (dgMostraAgendamentos.SelectedIndex >= 0)
            {
                a = (Agendamento)dgMostraAgendamentos.Items[dgMostraAgendamentos.SelectedIndex];

                new AgendamentoCadastro(a).Show();
            }
        }

        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Agendamentos
                    .Include(a => a.Pessoa)
                    .Include(a => a.Medico)
                    .Include(a => a.Plano);
                dgMostraAgendamentos.ItemsSource = consulta.ToList();

            }
        }
    }
}
