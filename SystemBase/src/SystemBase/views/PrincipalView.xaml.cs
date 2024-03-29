﻿using System.Windows;
using Stimulsoft.Report.Wpf;
using Stimulsoft.Report;
using ModeloDeDados.Classes;
using ModeloDeDados.Dados;
using System.Linq;

namespace SystemBase.views
{

    public partial class PrincipalView : Window
    {
        public PrincipalView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnPacienteCadastro_Click(object sender, RoutedEventArgs e)
        {
            new PacienteCadastroView().Show();
        }
        private void BtnBanco_Click(object sender, RoutedEventArgs e)
        {
            new BancoCadastroView().Show();
        }

        private void MiEstado_Click(object sender, RoutedEventArgs e)
        {
            new EstadoCadastroView().Show();
        }

        private void MiPlano_Click(object sender, RoutedEventArgs e)
        {
            new PlanoCadastroView().Show();
        }

        private void MiPais_Click(object sender, RoutedEventArgs e)
        {
            new PaisCadastroView().Show();
        }

        private void MiMedicamento_Click(object sender, RoutedEventArgs e)
        {
            new MedicamentoCadastroView().Show();
        }

        private void MiCidade_Click(object sender, RoutedEventArgs e)
        {
            new CidadeCadastroView().Show();
        }

        private void MiCep_Click(object sender, RoutedEventArgs e)
        {
            new CepCadastroView().Show();
        }

        private void MiMedico_Click(object sender, RoutedEventArgs e)
        {
            new MedicoCadastroView().Show();
        }

        private void MiUsuario_Click(object sender, RoutedEventArgs e)
        {
            new UsuarioCadastroView().Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnContasReceber_Click(object sender, RoutedEventArgs e)
        {
            new ContasReceberCadastroView().Show();
        }

        private void BtnContasPagar_Click(object sender, RoutedEventArgs e)
        {
            new ContasPagarCadastroView().Show();
        }

        private void MiAgendamento_Click(object sender, RoutedEventArgs e)
        {
            new AgendamentoCadastroView().Show();
        }

        private void BtnAgendamentosDoDia_Click(object sender, RoutedEventArgs e)
        {
            new AgendamentosDoDiaView().Show();
        }

        private void MiFaturaConsulta_Click(object sender, RoutedEventArgs e)
        {
            new FaturaConsultaView().Show();
        }

        private void BtnRelatorio_Click(object sender, RoutedEventArgs e)
        {

            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.ContasReceber;

                
                Faturamento cp = new Faturamento();
                StiReport report = new StiReport();

                report.RegData("ContasPagar", consulta.ToList());

                report.Load(@"C:\Users\Romário Moreira\Source\Repos\SistemaFinal\SystemBase\src\SystemBase\views\Teste.mrt");

                report.ShowWithWpf();
            }

        }
    }

}