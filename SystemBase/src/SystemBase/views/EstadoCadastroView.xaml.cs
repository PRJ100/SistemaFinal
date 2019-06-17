

using ModeloDeDados.Classes;
using ModeloDeDados.Dados;
using System.Linq;
using System.Windows;

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
        public EstadoCadastroView(Estado es)
        {
            InitializeComponent();
        }

        private void BtnNovoEstado_Click(object sender, RoutedEventArgs e)
        {
            new EstadoCadastro().Show();
        }

        private void BtnRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();

        }

        private void DgMostraEstados_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirEstado_Click(object sender, RoutedEventArgs e)
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

        private void BtnAlterarEstado_Click(object sender, RoutedEventArgs e)
        {
            Estado es = new Estado();
            if (dgMostraEstados.SelectedIndex >= 0)
            {
                es = (Estado)dgMostraEstados.Items[dgMostraEstados.SelectedIndex];

                new EstadoCadastro(es).Show();
            }
        }

        private void BtnVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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