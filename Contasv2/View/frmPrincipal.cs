using Contasv2.View;
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

namespace Contasv2
{
    public partial class Form1 : System.Windows.Forms.Form
    
    {
       public Form1()
        {
            InitializeComponent();
            carregaLista();
            
        }

        public double carregaLista()
        {
            double valorTotal = 0;
            List<ContaFixa> lst = new ContasController().Listar(new ContaFixa());

            dgvContas.Rows.Clear();

            for (int i = 0; i < lst.Count; i++)
            {
                DateTime dataAux1 = Convert.ToDateTime(lst[i].DataVencimento);

                if (lst[i].numParcerlas > 0)
                    if (dataAux1.Month <= DateTime.Today.Month && lst[i].DataPagamento == "Pendente")
                        if (dataAux1.Month <= DateTime.Today.Month)
                        {

                            dgvContas.Rows.Add(
                           lst[i].CodigoFixo,
                           lst[i].Descricao,
                           lst[i].DataVencimento,
                           lst[i].DataPagamento,
                           lst[i].numParcerlas,
                           lst[i].Tipo,
                           lst[i].Valor
                           );
                            valorTotal = lst[i].Valor + valorTotal;

                        }

            }

                textBox5.Text = Convert.ToString(valorTotal);
            
            return valorTotal;

    }

private void btnCadFixa_Click(object sender, EventArgs e)
        {
            new frmCadFixo("todos").ShowDialog();
            carregaLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmCadMovel("todos").ShowDialog();
            carregaLista();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgvContas.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro");
            }
            else
            {

             //   if(Convert.ToString(dgvContas.CurrentRow.Cells[4].Value) == "Movel")
             //   {
                   ContaFixa ctaf = new ContaFixa();



                ctaf.CodigoFixo = Convert.ToInt16(dgvContas.CurrentRow.Cells[0].Value);
                ctaf.Descricao = dgvContas.CurrentRow.Cells[1].Value.ToString();
                ctaf.DataVencimento = dgvContas.CurrentRow.Cells[2].Value.ToString();
                ctaf.DataPagamento = dgvContas.CurrentRow.Cells[3].Value.ToString();
                ctaf.numParcerlas = Convert.ToInt16(dgvContas.CurrentRow.Cells[4].Value);                
                ctaf.Valor = Convert.ToDouble(dgvContas.CurrentRow.Cells[6].Value);
                ctaf.Tipo = dgvContas.CurrentRow.Cells[5].Value.ToString();

                new frmEditConta(ctaf, "todos").ShowDialog();
                carregaLista();
                //  }

                // else
                // {
                //   ContaMovel ctam = new ContaMovel();
                //    new frmEditConta(ctam).ShowDialog();
                // }

            }

            
        }

        private void dgvContas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //

           
        }

        private void dgvContas_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvContas_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            
        }

        public List<ContaFixa> realizaPagamento(ContaFixa obj)
        {

            ContaFixa cf = new ContaFixa();




            return null;
        }

        private void dgvContas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgvContas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvContas_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }

        private void dgvContas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

       
        }

        private void Pagar_Click(object sender, EventArgs e)
        {

            String tipo = dgvContas.CurrentRow.Cells[5].Value.ToString();

            if (tipo == "Movel")
            {
                ContaMovel ctaf1 = new ContaMovel();

                ctaf1.CodigoMovel = Convert.ToInt16(dgvContas.CurrentRow.Cells[0].Value);
                ctaf1.Descricao = dgvContas.CurrentRow.Cells[1].Value.ToString();
                ctaf1.DataVencimento = dgvContas.CurrentRow.Cells[2].Value.ToString();
                ctaf1.DataPagamento = dgvContas.CurrentRow.Cells[3].Value.ToString();
                ctaf1.numParcerlas = Convert.ToInt16(dgvContas.CurrentRow.Cells[4].Value);
                ctaf1.Valor = Convert.ToDouble(dgvContas.CurrentRow.Cells[6].Value);
                ctaf1.Tipo = dgvContas.CurrentRow.Cells[5].Value.ToString();

                new ContasController().PagamentoMovel(ctaf1);

                carregaLista();
            }
            else
            {

                ContaFixa ctaf = new ContaFixa();


                ctaf.CodigoFixo = Convert.ToInt16(dgvContas.CurrentRow.Cells[0].Value);
                ctaf.Descricao = dgvContas.CurrentRow.Cells[1].Value.ToString();
                ctaf.DataVencimento = dgvContas.CurrentRow.Cells[2].Value.ToString();
                ctaf.DataPagamento = dgvContas.CurrentRow.Cells[3].Value.ToString();
                ctaf.numParcerlas = Convert.ToInt16(dgvContas.CurrentRow.Cells[4].Value);
                ctaf.Valor = Convert.ToDouble(dgvContas.CurrentRow.Cells[6].Value);
                ctaf.Tipo = dgvContas.CurrentRow.Cells[5].Value.ToString();

                new ContasController().Pagamento(ctaf);

                carregaLista();
            }
        }

        private void PagarMovel_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Excluir

            String tipo = dgvContas.CurrentRow.Cells[5].Value.ToString();

            if (tipo == "Movel")
            {
                int id;


                id = Convert.ToInt16(dgvContas.CurrentRow.Cells[0].Value);


                new ContasController().ExcluirMovel(id);

                carregaLista();
            }
            else
            {

                int id;


                id = Convert.ToInt16(dgvContas.CurrentRow.Cells[0].Value);


                new ContasController().ExcluirFixa(id);

                carregaLista();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            new frmOrcamento().ShowDialog();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new frmHome().ShowDialog();
        }
    }
    
}
