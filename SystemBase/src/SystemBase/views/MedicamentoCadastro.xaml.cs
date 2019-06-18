using ModeloDeDados.Classes;
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
    /// Lógica interna para MedicamentoCadastro.xaml
    /// </summary>
    public partial class MedicamentoCadastro : Window
    {
        private string op = "";
        public MedicamentoCadastro()
        {
            InitializeComponent();
            op = "";
        }
        public MedicamentoCadastro(Medicamento m)
        {
            InitializeComponent();
            op = "alterar";
            tbCodigo.Text = m.MedicamentoId.ToString();
            tbNome.Text = m.Nome;
            tbDescricao.Text = m.Descricao;
            tbNumeroRegistro.Text = m.NumeroRegistro.ToString();


        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
