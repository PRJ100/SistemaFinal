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
    /// Lógica interna para MedicamentoCadastroView.xaml
    /// </summary>
    public partial class MedicamentoCadastroView : Window
    {
        public MedicamentoCadastroView()
        {
            InitializeComponent();
        }

        private void BtnNovoMedicamento_Click(object sender, RoutedEventArgs e)
        {
            new MedicamentoCadastro().Show();
        }

        private void BtVolta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void BtRecarregar_Click(object sender, RoutedEventArgs e)
        {
            PreencherTabela();

        }

       

        private void BtnExcluirMedicamento_Click(object sender, RoutedEventArgs e)
        {
            if (dgMostraMedicamentos.SelectedIndex >= 0)
            {
                Medicamento m = (Medicamento)dgMostraMedicamentos.Items[dgMostraMedicamentos.SelectedIndex];


                using (DBContexto ctx = new DBContexto())
                {
                    m = ctx.Medicamentos.Find(m.MedicamentoId);
                    ctx.Medicamentos.Remove(m);
                    ctx.SaveChanges();
                }

            }
            PreencherTabela();
        }

        private void BtnAlterarMedicamento_Click(object sender, RoutedEventArgs e)
        {
            Medicamento m = new Medicamento();
            if (dgMostraMedicamentos.SelectedIndex >= 0)
            {
                m = (Medicamento)dgMostraMedicamentos.Items[dgMostraMedicamentos.SelectedIndex];

                new MedicamentoCadastro(m).Show();

            }
        }
     

        private void DgMostraMedicamentos_Loaded(object sender, RoutedEventArgs e)
        {
            PreencherTabela();

        }
        public void PreencherTabela()
        {
            using (DBContexto ctx = new DBContexto())
            {
                var consulta = ctx.Medicamentos;
                dgMostraMedicamentos.ItemsSource = consulta.ToList();
            }
        }

        private void BtnPesquisaBanco_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var consulta = from c in ctx.Medicamentos where c.Nome.Contains(tbPesquisa.Text) || c.Descricao.Contains(tbPesquisa.Text)
                                   select c;
                    dgMostraMedicamentos.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }
    }

}
