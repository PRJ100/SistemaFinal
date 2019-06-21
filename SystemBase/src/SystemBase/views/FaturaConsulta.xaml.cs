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
    /// Lógica interna para FaturaConsulta.xaml
    /// </summary>
    public partial class FaturaConsulta : Window
    {
        private List<Medico> medicos;
        private List<Pessoa> pessoas;
        private List<Plano> planos;

        public FaturaConsulta(Agendamento a)
        {
            InitializeComponent();
            PreencheComboBox();
            tbCodigoAgendamento.Text = a.AgendamentoId.ToString();
            cbTipo.Text = a.Tipo;
            dpDataConsulta.Text = a.DataConsulta.ToString();
            tpHoraConsulta.Text = a.HorarioConsuta;
            cbCodigoMedico.SelectedValue = a.MedicoId;
            cbCodigoPessoa.SelectedValue = a.PessoaId;
            cbCodigoPlano.SelectedValue = a.PlanoId;
        }

        private void BtnFatura_Click(object sender, RoutedEventArgs e)
        {
            Faturamento f = new Faturamento();


            f.Tipo = cbTipo.Text;
            f.DataConsulta = dpDataConsulta.SelectedDate.Value;
            f.HorarioConsuta = tpHoraConsulta.Text;
            f.MedicoId = Convert.ToInt32(cbCodigoMedico.SelectedValue);
            f.PessoaId = Convert.ToInt32(cbCodigoPessoa.SelectedValue);
            f.PlanoId = Convert.ToInt32(cbCodigoPlano.SelectedValue);
            f.Valor = Convert.ToDecimal(tbValor.Text);
            f.TipoPagamento = cbTipoPagamento.Text;

            using (DBContexto ctx = new DBContexto())
            {
                Agendamento a = ctx.Agendamentos.Find(Convert.ToInt32(tbCodigoAgendamento.Text));

                ctx.Agendamentos.Remove(a);
                ctx.Faturamentos.Add(f);
                ctx.SaveChanges();
            }
            this.Close();

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void PreencheComboBox()
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var item = ctx.Medicos.ToList();
                    medicos = item;
                    var item2 = ctx.Pessoas.ToList();
                    pessoas = item2;
                    var item3 = ctx.Planos.ToList();
                    planos = item3;

                    cbCodigoMedico.DataContext = medicos;
                    cbCodigoPessoa.DataContext = pessoas;
                    cbCodigoPlano.DataContext = planos;
                }
            }
            catch { }
        }

    }
}
