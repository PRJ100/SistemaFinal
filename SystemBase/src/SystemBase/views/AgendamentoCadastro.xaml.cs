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
    /// Lógica interna para AgendamentoCadastro.xaml
    /// </summary>
    public partial class AgendamentoCadastro : Window
    {
        private string op = "";
        private List<Medico> medicos;
        private List<Pessoa> pessoas;
        private List<Plano> planos;
        public AgendamentoCadastro()
        {
            InitializeComponent();
            PreencheComboBox();
            op = "";
        }
        public AgendamentoCadastro(Agendamento a)
        {
            InitializeComponent();
            PreencheComboBox();
            op = "alterar";
            tbCodigo.Text = a.AgendamentoId.ToString();
            cbTipo.Text = a.Tipo;
            dpDataConsulta.Text = a.DataConsulta.ToString();
            tpHoraConsulta.Text = a.HorarioConsuta;
            cbCodigoMedico.SelectedValue = a.MedicoId;
            cbCodigoPessoa.SelectedValue = a.PessoaId;
            cbCodigoPlano.SelectedValue = a.PlanoId;
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Agendamento a = new Agendamento();
            a.Tipo = cbTipo.Text;
            a.DataConsulta = dpDataConsulta.SelectedDate.Value;
            a.HorarioConsuta = tpHoraConsulta.Text;
            a.MedicoId = Convert.ToInt32(cbCodigoMedico.SelectedValue);
            a.PessoaId = Convert.ToInt32(cbCodigoPessoa.SelectedValue);
            a.PlanoId = Convert.ToInt32(cbCodigoPlano.SelectedValue);
            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    a = ctx.Agendamentos.Find(Convert.ToInt32(tbCodigo.Text));
                    if (a != null)
                    {
                        a.Tipo = cbTipo.Text;
                        a.DataConsulta = dpDataConsulta.SelectedDate.Value;
                        a.HorarioConsuta = tpHoraConsulta.Text;
                        a.MedicoId = Convert.ToInt32(cbCodigoMedico.SelectedValue);
                        a.PessoaId = Convert.ToInt32(cbCodigoPessoa.SelectedValue);
                        a.PlanoId = Convert.ToInt32(cbCodigoPlano.SelectedValue);
                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Agendamentos.Add(a);
                    ctx.SaveChanges();
                }
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
