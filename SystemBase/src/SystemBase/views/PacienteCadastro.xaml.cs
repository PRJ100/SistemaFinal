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
        public List<Cep> ceps { get; set; }
        public List<Cidade> cid { get; set; }
        public List<Cotato> cont { get; set; }
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
            cbContato.SelectedValue = p.ContatoId;
            cbCep.SelectedValue = p.CepId;
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
            p.ContatoId = Convert.ToInt32(cbContato.SelectedValue);
            p.CepId = Convert.ToInt32(cbCep.SelectedValue);
            p.CidadeId = Convert.ToInt32(cbCidade.SelectedValue);
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
                        p.ContatoId = Convert.ToInt32(cbContato.SelectedValue);
                        p.CepId = Convert.ToInt32(cbCep.SelectedValue);
                        p.CidadeId = Convert.ToInt32(cbCidade.SelectedValue);
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
                    var item = ctx.Ceps.ToList();
                    ceps = item;

                    var item2 = ctx.Cidades.ToList();
                    cid = item2;

                    var item3 = ctx.Contatos.ToList();
                    cont = item3;

                    cbCep.DataContext = ceps;
                    cbCidade.DataContext = cid;
                    cbContato.DataContext = cont;
                }
            }
            catch { }
        }
       

    }
}
