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
    /// Lógica interna para MedicoCadastro.xaml
    /// </summary>
    public partial class MedicoCadastro : Window
    {
        private string op = "";
        public MedicoCadastro()
        {
            InitializeComponent();
            op = "";
        }
        public MedicoCadastro(Medico m)
        {
            InitializeComponent();
            op = "alterar";
            tbCodigo.Text = m.MedicoId.ToString();
            tbCrm.Text = m.Crm.ToString();
            tbNome.Text = m.Nome;
            tbEspecialidade.Text = m.Especialidade;
            tbTelefone.Text = m.Telefone;
     }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Medico m = new Medico();
            m.Crm = tbCrm.Text;
            m.Nome= tbNome.Text;
            m.Especialidade = tbEspecialidade.Text;
            m.Telefone = tbTelefone.Text;

            

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    m = ctx.Medicos.Find(Convert.ToInt32(tbCodigo.Text));
                    if (m != null)
                    {
                        m.Crm = tbCrm.Text;
                        m.Nome = tbNome.Text;
                        m.Especialidade = tbEspecialidade.Text;
                        m.Telefone = tbTelefone.Text;

                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Medicos.Add(m);
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
