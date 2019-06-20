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
    /// Lógica interna para UsuarioCadastroView.xaml
    /// </summary>
    public partial class UsuarioCadastroView : Window
    {
        public UsuarioCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoUsuario_Click(object sender, RoutedEventArgs e)
        {
            new UsuarioCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void DgMostraUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();
        }

        private void BtnAlterarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario();
            if (dgMostraUsuarios.SelectedIndex >= 0)
            {
                u = (Usuario)dgMostraUsuarios.Items[dgMostraUsuarios.SelectedIndex];

                new UsuarioCadastro(u).Show();
            }
        }

        private void BtnExcluiUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraUsuarios.SelectedIndex >= 0)
            {
                Usuario u = (Usuario)dgMostraUsuarios.Items[dgMostraUsuarios.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    u = ctx.Usuarios.Find(u.UsuarioId);
                    ctx.Usuarios.Remove(u);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Usuarios;
                dgMostraUsuarios.ItemsSource = consulta.ToList();
            }
        }

        private void BtnPesquisaUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var consulta = from c in ctx.Usuarios where c.Login.Contains(tbPesquisa.Text)
                                   select c;
                    dgMostraUsuarios.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }
    }
}
