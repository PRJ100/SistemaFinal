using ModeloDeDados.Classes;
using ModeloDeDados.Dados;
using System.Linq;
using System.Windows;


namespace SystemBase.views
{
    /// <summary>
    /// Lógica interna para PaisCadastroView.xaml
    /// </summary>
    public partial class PaisCadastroView : Window
    {
        public PaisCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoPais_Click(object sender, RoutedEventArgs e)
        {
            new PaisCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void DgMostraPais_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirPais_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraPais.SelectedIndex >= 0)
            {
                Pais p = (Pais)dgMostraPais.Items[dgMostraPais.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    p = ctx.Paises.Find(p.PaisId);
                    ctx.Paises.Remove(p);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarPais_Click(object sender, RoutedEventArgs e)
        {
            Pais p = new Pais();
            if (dgMostraPais.SelectedIndex >= 0)
            {
                p = (Pais)dgMostraPais.Items[dgMostraPais.SelectedIndex];

                new PaisCadastro(p).Show();

            }
        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Paises;
                dgMostraPais.ItemsSource = consulta.ToList();
            }
        }
    }
}
