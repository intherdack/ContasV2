using Contasv2.Controller;
using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contasv2.View
{
    public partial class frmEditRec : Form
    {
        public frmEditRec(Receita alterar)
        {
            InitializeComponent();
            txtBanco.Text = alterar.Codigo.ToString();
            txtCodigo.Text = alterar.CodigoControle.ToString();
            txtCodigo.Enabled = false;
            txtDesc.Text = alterar.Descricao;
            txtValor.Text = alterar.Valor.ToString();
            dateCadastro.Text = alterar.Data;
            dateCadastro.Enabled = false;

            if (alterar.Obs == "Mensal")
            {
                continuo.Checked = true;
            }
            else
            {
                txtMeses.Text = alterar.Obs;
            }

        }

        private void frmEditRec_Load(object sender, EventArgs e)
        {

        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Receita alt = new Receita();
            bool validado = true;
            

            //Valida os Dados
            if (String.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show("Preencha o Campo Descrição!");
                validado = false;
            }

            if (String.IsNullOrEmpty(txtValor.Text))
            {
                MessageBox.Show("Preencha o Campo Valor!");
                validado = false;

            }
            if (Convert.ToInt16(txtMeses.Text.Trim()) == 0)
            {
                MessageBox.Show("Valor INCORRETO para número de meses");
                txtMeses.Text = "1";
                validado = false;
            }
            if (validado == true)
            {
                alt.Codigo = Convert.ToInt32(txtBanco.Text);
                alt.Descricao = txtDesc.Text;
                alt.Data = dateCadastro.Text;
                alt.Valor = new ValidacaoController().CorrigeDouble(txtValor.Text);
                alt.CodigoControle = Convert.ToInt32(txtCodigo.Text);
                if (continuo.Checked == true)
                {
                    alt.Obs = "Mensal";
                }
                else
                {
                    alt.Obs = txtMeses.Text;
                }

                if(continuo.Checked == true)
                {
                    new ContasController().ExcluirRec(alt.CodigoControle);
                    new ContasController().IncluirContinuoRec(alt);
                    MessageBox.Show("Aterado Com Sucesso");
                    Close();
                }
                else
                {
                    new ContasController().ExcluirRec(alt.CodigoControle);
                    new ContasController().IncluirConfParcelasRec(alt);
                    MessageBox.Show("Aterado Com Sucesso");
                    Close();
                }
                
            }
        }

        private void continuo_CheckedChanged(object sender, EventArgs e)
        {
            if (continuo.Checked == true)
            {
                continuo.Enabled = true;
                txtMeses.Enabled = false;
            }
            if (continuo.Checked == false)
            {

                txtMeses.Enabled = true;
            }
        }

        private void txtMeses_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
