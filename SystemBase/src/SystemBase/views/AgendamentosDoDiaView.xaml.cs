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
    /// Lógica interna para AgendamentosDoDiaView.xaml
    /// </summary>
    public partial class AgendamentosDoDiaView : Window
    {
        public AgendamentosDoDiaView()
        {
            InitializeComponent();
        }

        private void BtnNovoAgendamento_Click(object sender, RoutedEventArgs e)
        {
            new AgendamentoCadastro().Show();
        }

        private void BtnVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void DgMostraAgendametosDoDia_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = from c in ctx.Agendamentos
                    .Include(c => c.Pessoa)
                               where c.DataConsulta.Equals(DateTime.Today)
                               select c;
                dgMostraAgendametosDoDia.ItemsSource = consulta.ToList();

            }
        }

        private void BtnChegou_Click(object sender, RoutedEventArgs e)
        {
            Agendamento a = new Agendamento();
            using (DBContexto ctx = new DBContexto())
            {
                if (dgMostraAgendametosDoDia.SelectedIndex >= 0)
                {

                    a = (Agendamento)dgMostraAgendametosDoDia.Items[dgMostraAgendametosDoDia.SelectedIndex];

                    a = ctx.Agendamentos.Find(Convert.ToInt32(a.AgendamentoId));
                    if (a != null)
                    {
                        a.Status = "Aguardando";
                        ctx.SaveChanges();
                    }
                }
            }
            
            PreencherTabela();

        }

        private void BtnIniciarConsulta_Click(object sender, RoutedEventArgs e)
        {
            Agendamento a = new Agendamento();
            using (DBContexto ctx = new DBContexto())
            {
                if (dgMostraAgendametosDoDia.SelectedIndex >= 0)
                {

                    a = (Agendamento)dgMostraAgendametosDoDia.Items[dgMostraAgendametosDoDia.SelectedIndex];

                    a = ctx.Agendamentos.Find(Convert.ToInt32(a.AgendamentoId));
                    if (a != null)
                    {
                        a.Status = "Em Consulta";
                        ctx.SaveChanges();
                    }
                }
            }

            PreencherTabela();
        }

        private void BtnFinalizarConsulta_Click(object sender, RoutedEventArgs e)
        {
            Agendamento a = new Agendamento();
            using (DBContexto ctx = new DBContexto())
            {
                if (dgMostraAgendametosDoDia.SelectedIndex >= 0)
                {

                    a = (Agendamento)dgMostraAgendametosDoDia.Items[dgMostraAgendametosDoDia.SelectedIndex];

                    a = ctx.Agendamentos.Find(Convert.ToInt32(a.AgendamentoId));
                    if (a != null)
                    {
                        a.Status = "Finalizada";
                        ctx.SaveChanges();
                    }
                }
            }

            PreencherTabela();
        }
    }
}
