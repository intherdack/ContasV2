
using Contasv2.Controller;
using Controller;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class frmEditConta : System.Windows.Forms.Form
    {

        public frmEditConta(Model.ContaFixa cf)
        {
            InitializeComponent();



            //passando valores
            textCodigoB.Text = cf.CodigoFixo.ToString();
            txtCodigo.Enabled = false;
            txtDescricao.Text = cf.Descricao;
            txtDataVenc.Text = cf.DataVencimento;
            txtDataPag.Text = cf.DataPagamento;
            txtDataPag.Enabled = false;
            txtTipo.Text = cf.Tipo;
            txtTipo.Enabled = false;
            txtValor.Text = cf.Valor.ToString();
            txtParcelas.Text = cf.numParcerlas.ToString();
            txtParcelas.Enabled = false;
            txtCodigo.Text = cf.codigoConta.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Salvar
        private void button1_Click(object sender, EventArgs e)
        {
            //passando valor para comparar
            String tipo = txtTipo.Text.ToString();

            if (tipo == "Fixo" || tipo == "Mensal")
            {
                //salva sim o não para alterar
                DialogResult confirm = MessageBox.Show("ATENÇÃO todas as contas serão alteradas, com exeção das contas pagas!", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                // valida se o clique foi sim e recebe os valores
                if (confirm.ToString().ToUpper() == "YES")
                {
                    
                    ContaFixa obj = new ContaFixa();
                    obj.CodigoFixo = Convert.ToInt16(textCodigoB.Text);
                    obj.Descricao = txtDescricao.Text.ToString();
                    obj.DataVencimento = txtDataVenc.Text.ToString();
                    obj.DataPagamento = txtDataPag.Text.ToString();
                    obj.numParcerlas = Convert.ToInt32(txtParcelas.Text);
                    obj.Valor = new ValidacaoController().CorrigeDouble(txtValor.Text);
                    obj.Tipo = txtTipo.Text.ToString();
                    obj.codigoConta = Convert.ToInt16(txtCodigo.Text);

                    List<ContaFixa> lst1 = new ContasController().Listar(new ContaFixa());
                    ContaFixa obj2 = new ContaFixa();



                    //faz a alteração em todas contas fixas cadastradas com exeção dos valores nas contas pagas
                     for (int i = 0; i < lst1.Count; i++)
                     {
                       if (lst1[i].codigoConta == obj.codigoConta)
                       {

                           obj2.CodigoFixo = lst1[i].CodigoFixo;
                           obj2.Descricao = txtDescricao.Text.ToString();
                           obj2.DataVencimento = lst1[i].DataVencimento;
                           obj2.DataPagamento = lst1[i].DataPagamento;
                           obj2.numParcerlas = lst1[i].numParcerlas;

                            DateTime aux = Convert.ToDateTime(obj.DataVencimento);

                            DateTime aux2 = Convert.ToDateTime(lst1[i].DataVencimento);



                            String datafinal = aux.Day.ToString() + "/" + aux2.Month.ToString() + "/" + aux2.Year.ToString();
                            obj2.DataVencimento = datafinal;

                            //valida se a conta esta paga, se não foi paga faz a alteração do valor
                            if (lst1[i].DataPagamento == "Pendente")
                           {
                               obj2.Valor = Convert.ToDouble(txtValor.Text);
                           }
                           else
                           {
                               obj2.Valor = lst1[i].Valor;
                           }
                           obj2.Tipo = txtTipo.Text.ToString();
                           obj2.codigoConta = lst1[i].codigoConta;

                           new ContasController().atualizaContaFixa(obj2);

                       }

                     }
                   

                   // new ContasController().atualizaContaFixa(obj);
                    MessageBox.Show("Conta " + obj.Descricao + " Atualizada Com Sucessso");
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            if (tipo == "Movel")
            {
                
                ContaMovel lst1 = new ContaMovel();
                lst1.CodigoMovel = Convert.ToInt16(textCodigoB.Text);
                lst1.Descricao = txtDescricao.Text.ToString();
                lst1.DataVencimento = txtDataVenc.Text.ToString();
                lst1.DataPagamento = txtDataPag.Text.ToString(); 
                lst1.numParcerlas = Convert.ToInt32(txtParcelas.Text);
                lst1.Valor = new ValidacaoController().CorrigeDouble(txtValor.Text);
                lst1.Tipo = txtTipo.Text.ToString();
                lst1.codigoConta = Convert.ToInt16(txtCodigo.Text);

                new ContasController().atualizaContaMovel(lst1);
               MessageBox.Show("Conta " + lst1.Descricao + " Atualizada Com Sucessso");
                this.Close();
            }
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
