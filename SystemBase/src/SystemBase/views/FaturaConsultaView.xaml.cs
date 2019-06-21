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
    /// Lógica interna para FaturaConsultaView.xaml
    /// </summary>
    public partial class FaturaConsultaView : Window
    {
        public FaturaConsultaView()
        {
            InitializeComponent();
        }

        private void DgMostraFaturaConsulta_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = from c in ctx.Agendamentos
                    .Include(c => c.Pessoa)
                    .Include(c => c.Plano)
                    .Include(c => c.Medico)
                               where c.DataConsulta.Equals(DateTime.Today) && c.Status == "Finalizada"
                               select c;
                dgMostraFaturaConsulta.ItemsSource = consulta.ToList();

            }

        }

        private void BtnReabrirConsulta_Click(object sender, RoutedEventArgs e)
        {
            Agendamento a = new Agendamento();
            using (DBContexto ctx = new DBContexto())
            {
                if (dgMostraFaturaConsulta.SelectedIndex >= 0)
                {

                    a = (Agendamento)dgMostraFaturaConsulta.Items[dgMostraFaturaConsulta.SelectedIndex];

                    a = ctx.Agendamentos.Find(Convert.ToInt32(a.AgendamentoId));
                    if (a != null)
                    {
                        a.Status = "";
                        ctx.SaveChanges();
                    }
                }
            }

            PreencherTabela();
            new AgendamentosDoDiaView().Show();
            this.Close();
        }

        private void BtnFaturarConsulta_Click(object sender, RoutedEventArgs e)
        {
            Agendamento a = new Agendamento();
            using (DBContexto ctx = new DBContexto())
            {
                if (dgMostraFaturaConsulta.SelectedIndex >= 0)
                {

                    a = (Agendamento)dgMostraFaturaConsulta.Items[dgMostraFaturaConsulta.SelectedIndex];

                    a = ctx.Agendamentos.Find(Convert.ToInt32(a.AgendamentoId));
                    if (a != null)
                    {
                        new FaturaConsulta(a).Show();
                    }
                }
            }
        }
    }
}
