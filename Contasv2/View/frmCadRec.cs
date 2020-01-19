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
    public partial class frmCadRec : System.Windows.Forms.Form
    {
        String mesCadastro;
        public frmCadRec(string mes)
        {
            
            this.mesCadastro = mes;
            InitializeComponent();

            DateTime defineData = DateTime.Now;

            String dia1, ano1, nvData;

            dia1 = defineData.Day.ToString();
            ano1 = defineData.Year.ToString();
            nvData = dia1 + "/" + mesCadastro + "/" + ano1;
            defineData = Convert.ToDateTime(nvData);
            dateCadastro.Value = defineData;
            dateCadastro.Enabled = false;
            txtMeses.Text = 1.ToString();

            //cria um codigo alertorio para conta
            int um, dois, tres;
            um = Convert.ToInt32(DateTime.Today.DayOfYear);
            dois = Convert.ToInt32(DateTime.Now.DayOfWeek);
            tres = DateTime.Now.Millisecond;
            int hash = um + dois + tres;
            txtCodigo.Text = hash.ToString();
            txtCodigo.Enabled = false;
        }

        private void frmCadRec_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            bool validado = true;
            Receita r = new Receita();

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
            if (String.IsNullOrEmpty(txtMeses.Text))
            {
                MessageBox.Show("Preencha o Campo Meses!");
                txtMeses.Text = "1";
                validado = false;
            }
            else
            {
                
                if (Convert.ToInt16(txtMeses.Text.Trim()) == 0 && continuo.Checked == false)
                {
                    
                    MessageBox.Show("Valor INCORRETO para número de meses");
                    validado = false;
                }
            }

            if (validado == true)
            {
                if (Convert.ToInt32(txtMeses.Text.Trim()) != 0)
                {
                    r.Descricao = txtDesc.Text;
                    r.Data = Convert.ToString(dateCadastro.Text);
                    r.Valor = new ValidacaoController().CorrigeDouble(txtValor.Text);
                    r.CodigoControle = Convert.ToInt16(txtCodigo.Text);

                    if (continuo.Checked == true)
                    {
                        r.Obs = "Mensal";
                    }
                    else
                    {
                        r.Obs = txtMeses.Text;
                    }


                    new ContasController().IncluirConfParcelasRec(r);
                    MessageBox.Show("Cadastrado com Sucesso");
                    this.Close();

                }
                else
                {
                    r.Descricao = txtDesc.Text;
                    r.Data = Convert.ToString(dateCadastro.Text);
                    r.Valor = new ValidacaoController().CorrigeDouble(txtValor.Text);
                    r.CodigoControle = Convert.ToInt16(txtCodigo.Text);

                    if (continuo.Checked == true)
                    {
                        r.Obs = "Mensal";
                    }
                    else
                    {
                        r.Obs = txtMeses.Text;
                    }
                    new ContasController().IncluirContinuoRec(r);
                    MessageBox.Show("Cadastrado com Sucesso, Do mês atual até Dezembro");

                    this.Close();
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            continuo.Enabled = false;
            txtMeses.Enabled = true;
        }

        private void continuo_CheckedChanged(object sender, EventArgs e)
        {
            if (continuo.Checked == true)
            {
                continuo.Enabled = true;
                txtMeses.Enabled = false;

                txtMeses.Text = 0.ToString();
            }
            if (continuo.Checked == false)
            {
                
                txtMeses.Enabled = true;
            }
        }

        private void txtMeses_MouseLeave(object sender, EventArgs e)
        {
            
        }
    }
}
