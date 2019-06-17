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
    /// Lógica interna para ContatoCadastroView.xaml
    /// </summary>
    public partial class ContatoCadastroView : Window
    {
        public ContatoCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoContato_Click(object sender, RoutedEventArgs e)
        {
            new ContatoCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void DgMostraContatos_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnExcluirContato_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraContatos.SelectedIndex >= 0)
            {
                Cotato c = (Cotato)dgMostraContatos.Items[dgMostraContatos.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    c = ctx.Contatos.Find(c.ContatoId);
                    ctx.Contatos.Remove(c);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarContato_Click(object sender, RoutedEventArgs e)
        {
            Cotato c = new Cotato();
            if (dgMostraContatos.SelectedIndex >= 0)
            {
                c = (Cotato)dgMostraContatos.Items[dgMostraContatos.SelectedIndex];

                new ContatoCadastro(c).Show();

            }
        }

        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Contatos;
                dgMostraContatos.ItemsSource = consulta.ToList();
            }
        }
    }
}
