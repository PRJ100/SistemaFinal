using ModeloDeDados.Classes;
using ModeloDeDados.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SystemBase.views
{
    /// <summary>
    /// Lógica interna para PacienteCadastro.xaml
    /// </summary>
    public partial class PacienteCadastro : Window
    {
        public List<Cidade> cid { get; set; }
        private string op = "";
        public PacienteCadastro()
        {
            InitializeComponent();
            PreencherComboBox();
            op = "";
        }

        public PacienteCadastro(Pessoa p)
        {
            InitializeComponent();
            PreencherComboBox();
            op = "alterar";
            tbNome.Text = p.Nome;
            tbCpf.Text = p.CPF;
            tbRg.Text = p.RG;
            tbNomeMae.Text = p.NomeMae;
            tbNomePai.Text = p.NomePai;
            cbEstadoCivil.Text = p.EstadoCivil;
            dpNascimento.Text = p.Nascimento.ToString();
            tbIdade.Text = p.Idade.ToString();
            cbSexo.Text = p.Sexo;
            tbNaturidade.Text = p.Naturalidade;
            tbCepRua.Text = p.CepRua;
            tbContato.Text = p.Contato;
            cbCidade.SelectedValue = p.CidadeId;
            tbLogradouro.Text = p.Logradouro;
            tbBairro.Text = p.Bairro;
            tbNumero.Text = p.Numero;
            tbComplemento.Text = p.Complemento;
            dpDataCadastro.Text = p.DataCadastro.ToString();
            cbStatus.Text = p.Status;
            tbCodigo.Text = p.PessoaId.ToString();
            tbDataAlteracao.Text = p.DataAlteracao.ToString();
            cbTipoPessoa.Text = p.TipoPessoa;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pessoa p = new Pessoa();

            p.Nome = tbNome.Text;
            p.CPF = tbCpf.Text;
            p.RG = tbRg.Text;
            p.NomeMae = tbNomeMae.Text;
            p.NomePai = tbNomePai.Text;
            p.EstadoCivil = cbEstadoCivil.Text;
            p.Nascimento = dpNascimento.SelectedDate.Value;
            p.Idade = Convert.ToInt32(tbIdade.Text);
            p.Sexo = cbSexo.Text;
            p.Naturalidade = tbNaturidade.Text;
            p.CepRua = tbCepRua.Text;
            p.CidadeId = Convert.ToInt32(cbCidade.SelectedValue);
            p.Contato = tbContato.Text;
            p.Logradouro = tbLogradouro.Text;
            p.Bairro = tbBairro.Text;
            p.Numero = tbNumero.Text;
            p.Complemento = tbComplemento.Text;
            p.DataCadastro = dpDataCadastro.SelectedDate.Value;
            p.Status = cbStatus.Text;
            p.TipoPessoa = cbTipoPessoa.Text;

            if (op == "alterar")
            {
                using (DBContexto ctx = new DBContexto())
                {
                    p = ctx.Pessoas.Find(Convert.ToInt32(tbCodigo.Text));
                    if (p != null)
                    {
                        p.Nome = tbNome.Text;
                        p.CPF = tbCpf.Text;
                        p.RG = tbRg.Text;
                        p.NomeMae = tbNomeMae.Text;
                        p.NomePai = tbNomePai.Text;
                        p.EstadoCivil = cbEstadoCivil.Text;
                        p.Nascimento = dpNascimento.SelectedDate.Value;
                        p.Idade = Convert.ToInt32(tbIdade.Text);
                        p.Sexo = cbSexo.Text;
                        p.Naturalidade = tbNaturidade.Text;
                        p.CepRua = tbCepRua.Text;
                        p.CidadeId = Convert.ToInt32(cbCidade.SelectedValue);
                        p.Contato = tbContato.Text;
                        p.Logradouro = tbLogradouro.Text;
                        p.Bairro = tbBairro.Text;
                        p.Numero = tbNumero.Text;
                        p.Complemento = tbComplemento.Text;
                        p.DataCadastro = dpDataCadastro.SelectedDate.Value;
                        p.Status = cbStatus.Text;
                        p.TipoPessoa = cbTipoPessoa.Text;

                        ctx.SaveChanges();
                    }
                }
            }
            else
            {
                using (var ctx = new DBContexto())
                {
                    ctx.Pessoas.Add(p);
                    ctx.SaveChanges();
                }
            }
            this.Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void PreencherComboBox()
        {
            try
            {
                using (DBContexto ctx = new DBContexto())
                {
                    var item = ctx.Cidades.ToList();
                    cid = item;
                    cbCidade.DataContext = cid;
                }
            }
            catch { }
        }


    }
}
