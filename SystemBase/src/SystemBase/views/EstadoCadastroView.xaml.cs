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
    /// Lógica interna para EstadoCadastroView.xaml
    /// </summary>
    public partial class EstadoCadastroView : Window
    {
        public EstadoCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoEstado_Click(object sender, RoutedEventArgs e)
        {
            new EstadoCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();

        }

        private void BtnExcluirEstado_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAlterarEstado_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraEstados.SelectedIndex >= 0)
            {
                Estado es = (Estado)dgMostraEstados.Items[dgMostraEstados.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    es = ctx.Estados.Find(es.EstadoId);
                    ctx.Estados.Remove(es);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }


        private void DgMostraEstados_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Estados;
                dgMostraEstados.ItemsSource = consulta.ToList();
            }
        }
    }
}