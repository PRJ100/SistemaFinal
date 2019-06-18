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
            Medicamento m = new Medicamento();
            m.Nome = tbNome.Text;
            m.Descricao = tbDescricao.Text;
            m.NumeroRegistro = Convert.ToInt32(tbNumeroRegistro.Text);

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    m = ctx.Medicamentos.Find(Convert.ToInt32(tbCodigo.Text));
                    if (m != null)
                    {
                        m.Nome = tbNome.Text;
                        m.Descricao = tbDescricao.Text;
                        m.NumeroRegistro = Convert.ToInt32(tbNumeroRegistro.Text);

                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Medicamentos.Add(m);
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
