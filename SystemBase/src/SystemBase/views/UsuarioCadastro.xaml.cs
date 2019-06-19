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
    /// Lógica interna para UsuarioCadastro.xaml
    /// </summary>
    public partial class UsuarioCadastro : Window
    {
        private string op = "";
     
        public UsuarioCadastro()
        {
            InitializeComponent();
             op = "";
        }
        public UsuarioCadastro(Usuario u)
        {
            InitializeComponent();
            op = "alterar";

            tbCodigo.Text = u.UsuarioId.ToString();
            tbLogin.Text = u.Login;
            tbSenha.Text = u.Senha;
            cbNivelDeAcesso.Text = u.nivelAcesso.ToString();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario();
            u.Login = tbLogin.Text;
            u.Senha = tbSenha.Text;
            u.nivelAcesso = Convert.ToInt32(cbNivelDeAcesso.Text);
            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    u = ctx.Usuarios.Find(Convert.ToInt32(tbCodigo.Text));
                    if (u != null)
                    {

                        u.Login = tbLogin.Text;
                        u.Senha = tbSenha.Text;
                        u.nivelAcesso = Convert.ToInt32(cbNivelDeAcesso.Text);
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Usuarios.Add(u);
                    ctx.SaveChanges();
                }
            }

            this.Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
     
        }
    }

