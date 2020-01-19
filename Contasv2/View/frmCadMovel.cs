
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
    public partial class frmCadMovel : System.Windows.Forms.Form
    {
        String test2;
        public frmCadMovel(String mes)
        {
            this.test2 = mes;
            InitializeComponent();

            DateTime defineData = DateTime.Now;

            String dia1, ano1, nvData;

            dia1 = defineData.Day.ToString();
            ano1 = defineData.Year.ToString();
            nvData = dia1 + "/" + test2 + "/" + ano1;
            defineData = Convert.ToDateTime(nvData);
            dateTimePicker1.Value = defineData;
        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            ContaMovel lst = new ContaMovel();
            
            bool validado = true;


            //Valida os Dados
            if (String.IsNullOrEmpty(txtDesc.Text))
            {
                System.Windows.Forms.MessageBox.Show("Preencha o Campo Descrição!");
                validado = false;
            }

            if (String.IsNullOrEmpty(dateTimePicker1.Text))
            {
                System.Windows.Forms.MessageBox.Show("Preencha  o Campo Data de Vencimento!!");
                validado = false;
            }

            if (String.IsNullOrEmpty(txtValor.Text))
            {
                System.Windows.Forms.MessageBox.Show("Preencha o Campo Valor!");
                validado = false;

            }

            

            if (validado == true)
            {
                lst.Descricao = txtDesc.Text;
                lst.DataVencimento = Convert.ToString(dateTimePicker1.Text);
                lst.Valor = new ValidacaoController().CorrigeDouble(txtValor.Text);
                lst.numParcerlas = 1;
                lst.DataPagamento = "Pendente";

                    new ContasController().IncluirContaMovel(lst);
                    MessageBox.Show("Salvo com sucesso!");
                    this.Close();

            }
        }

        private void frmCadMovel_Load(object sender, EventArgs e)
        {

        }
    }
}
