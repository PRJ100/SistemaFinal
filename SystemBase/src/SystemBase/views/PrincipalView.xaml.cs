using System;
using System.Collections.Generic;
using System.Windows;

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
    }

}
