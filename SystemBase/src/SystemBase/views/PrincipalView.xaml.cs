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

        private void MiContato_Click(object sender, RoutedEventArgs e)
        {
            new ContatoCadastroView().Show();
        }

        private void BtnBanco_Click(object sender, RoutedEventArgs e)
        {
            new BancoCadastroView().Show();
        }
    }
}
