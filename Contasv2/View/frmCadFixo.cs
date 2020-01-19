
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
    public partial class frmCadFixo : System.Windows.Forms.Form
    {
        String mesCadastro;
        public frmCadFixo(String mes)
        {
            this.mesCadastro = mes;
            InitializeComponent();

            DateTime defineData = DateTime.Now;

            String dia1, ano1, nvData;

            dia1 = defineData.Day.ToString();
            ano1 = defineData.Year.ToString();
            nvData = dia1 + "/" + mesCadastro + "/" + ano1;
            defineData = Convert.ToDateTime(nvData);
            dateTimePicker1.Value = defineData;
        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            
            ContaFixa lst = new ContaFixa();

            bool validado = true;


            //Valida os dados
            if (String.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show("Preencha o Campo Descrição!");
                validado = false;
            }

            if (String.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Preencha  o Campo Data de Vencimento!!");
                validado = false;
            }

            if(continuo.Checked == false){
                if (String.IsNullOrEmpty(txtValor.Text))
                {
                    MessageBox.Show("Preencha o Campo Valor!");
                    validado = false;

                }

                if (String.IsNullOrEmpty(txtParcelas.Text) || Convert.ToInt32(txtParcelas.Text) <= 0)
                {
                    
                    MessageBox.Show("Insira um número de parcelas válidas!");
                    validado = false;
                }
            }

            

            if (validado == true)
            {
                lst.Descricao = txtDesc.Text;
                // lst.DataVencimento = txtData.Text;
                lst.DataVencimento = Convert.ToString(dateTimePicker1.Text);
                if (txtValor.Text == "")
                {

                    lst.Valor = Convert.ToDouble(0);
                }
                else
                {
                    lst.Valor = new ValidacaoController().CorrigeDouble(txtValor.Text);
                }

                if (txtParcelas.Text == "")
                {

                    lst.numParcerlas = Convert.ToInt16(0);
                }
                else
                {
                    lst.numParcerlas = Convert.ToInt16(txtParcelas.Text);
                }

                
                lst.DataPagamento = "Pendente";


                //aqui decide qual metodo de salvar será invocado
                int dia, mes, ano;
                DateTime dataAux = Convert.ToDateTime(lst.DataVencimento);

                dia = dataAux.Day;
                ano = dataAux.Year;
                mes = dataAux.Month;

                if (lst.numParcerlas == 0 && mes != 12)
                {
                    new ContasController().IncluirContinuo(lst);
                    MessageBox.Show("Salvo com sucesso!");

                }
                else
                {
                    new ContasController().IncluirConfParcelas(lst);
                    MessageBox.Show("Salvo com sucesso!");
                }
                

                   
                
                this.Close();
                

            }



        }
       





        private void frmCadFixo_Load(object sender, EventArgs e)
        {

        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtParcelas_TextChanged(object sender, EventArgs e)
        {
            if(txtParcelas.Text == null)
            {
                //ativa o check box
                continuo.Enabled = true;
            }
            else
            {
                //se estiver null desativa check box
                continuo.Enabled = false;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void continuo_CheckStateChanged(object sender, EventArgs e)
        {
            if (continuo.Checked == true)
            {
                //desativa parcelas
                txtParcelas.Enabled = false;
                //prenche com null para salvar no banco
                txtParcelas.Text = null;
            }
            else
            {
                //ativa parcelas
                txtParcelas.Enabled = true;
            }
        }
    }

       
 }

