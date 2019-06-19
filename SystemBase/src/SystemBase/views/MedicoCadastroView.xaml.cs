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
    /// Lógica interna para MedicoCadastroView.xaml
    /// </summary>
    public partial class MedicoCadastroView : Window
    {
        public MedicoCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoMedico_Click(object sender, RoutedEventArgs e)
        {
            new MedicoCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void DgMostraMedico_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirMedico_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraMedico.SelectedIndex >= 0)
            {
                Medico m = (Medico)dgMostraMedico.Items[dgMostraMedico.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    m = ctx.Medicos.Find(m.Crm);
                    ctx.Medicos.Remove(m);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarMedico_Click(object sender, RoutedEventArgs e)
        {
            Medico m = new Medico();
            if (dgMostraMedico.SelectedIndex >= 0)
            {
                m = (Medico)dgMostraMedico.Items[dgMostraMedico.SelectedIndex];

                new MedicoCadastro(m).Show();

            }
        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Medicos;
                dgMostraMedico.ItemsSource = consulta.ToList();
            }
        }

    }
}
