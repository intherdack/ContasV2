using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Contasv2.View
{
    public partial class frmMes : Form
    {
        int mes = 0;
        List<Receita> lstRec = new List<Receita>();
        DateTime dataVenci;
        String anobusca;
        int recMesPesquisa;
        public frmMes()
        {
            InitializeComponent();
        }

        public double carregaLista(int mesPesquisa)
        {
            this.mes = mesPesquisa;
            recMesPesquisa = mesPesquisa;
            anobusca = anoBusca.Text.ToString(); //pegando ano de busca para comparacao
            double valorTotal = 0;
            double pendencias = 0;
            double pagas = 0;


            List<ContaFixa> lst = new ContasController().Listar(new ContaFixa());
            dgvContas.Rows.Clear();

            /*****************************************************************************/

            

            for (int i = 0; i < lst.Count; i++)
            {
                dataVenci = Convert.ToDateTime(lst[i].DataVencimento);
                String ano = Convert.ToString(DateTime.Now.Year);
                String dataAux2 = Convert.ToString(dataVenci.Year);

                if (anobusca == "") //pega o ano atual se nao estiver preenchido!
                {
                    anobusca = ano;
                }

                if (dataVenci.Month == mesPesquisa)
                { //valida se a conta pertence ao mes de janeiro

                    if (anobusca == dataAux2)//Valida ano de busca
                    {
                        dgvContas.Rows.Add(
                        lst[i].CodigoFixo,
                        lst[i].Descricao,
                        lst[i].DataVencimento,
                        lst[i].DataPagamento,
                        lst[i].numParcerlas,
                        lst[i].Tipo,
                        lst[i].Valor,
                        lst[i].codigoConta
                        
                        );
                        valorTotal = lst[i].Valor + valorTotal;

                        if (lst[i].DataPagamento != "Pendente")
                        {
                            pagas = lst[i].Valor + pagas;
                        }
                        else
                        {
                            pendencias = lst[i].Valor + pendencias;
                        }
                    }
                }
            }


            //passa a soma total do mes para a tela Mes
            textBox5.Enabled = false;
            textBox5.Text = "R$ " + Convert.ToString(valorTotal);
            textBoxPendentes.Enabled = false;
            textBoxPendentes.Text = "R$ " + Convert.ToString(pendencias);
            textBoxPagas.Enabled = false;
            textBoxPagas.Text = "R$ " + Convert.ToString(pagas);
            txtReceitasMes.Enabled = false;
           if(anobusca == "")
            {
                DateTime auxdate = DateTime.UtcNow;

                anobusca = Convert.ToInt32(auxdate.Year).ToString();
            }
            lstRec = new ContasController().BuscaReceitaMes(mesPesquisa, Convert.ToInt32(anobusca));
            if(lstRec.Count !=0)
            txtLiquidaMes.Text = "R$ " + Convert.ToString(lstRec[lstRec.Count() - 1].soma - pagas);
            txtLiquidaMes.Enabled = false;
            




            if (lstRec.Count != 0)
            {
                txtReceitasMes.Text = "R$ " + lstRec[lstRec.Count() - 1].soma.ToString();

            }
            else
            {
                txtReceitasMes.Text = "Sem Receita";
                txtLiquidaMes.Text = "";
            }

            //Decide o mes da janela e retorna para a tela Mes
            switch (this.mes)
            {
                case 1:
                    labelnome.Text = "Janeiro";
                    break;
                case 2:
                    labelnome.Text = "Fevereiro";
                    break;
                case 3:
                    labelnome.Text = "Março";
                    break;
                case 4:
                    labelnome.Text = "Abril";
                    break;
                case 5:
                    labelnome.Text = "Maio";
                    break;
                case 6:
                    labelnome.Text = "Junho";
                    break;
                case 7:
                    labelnome.Text = "Julho";
                    break;
                case 8:
                    labelnome.Text = "Agosto";
                    break;
                case 9:
                    labelnome.Text = "Setembro";
                    break;
                case 10:
                    labelnome.Text = "Outubro";
                    break;
                case 11:
                    labelnome.Text = "Novembro";
                    break;
                case 12:
                    labelnome.Text = "Dezembro";
                    break;
                default:
                    labelnome.Text = "Mes Atual";
                    break;
            }

            return valorTotal;
        }


        private void dgvContas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            carregaLista(this.mes);

        }

        private void anoBusca_TextChanged(object sender, EventArgs e)
        {

        }


        //excluir
        private void button2_Click(object sender, EventArgs e)
        {
            String tipo = dgvContas.CurrentRow.Cells[5].Value.ToString();
            String desc = dgvContas.CurrentRow.Cells[1].Value.ToString();
            int id_secundario = Convert.ToInt32(dgvContas.CurrentRow.Cells[7].Value);

            //valida se a conta ja foi paga
            if (dgvContas.CurrentRow.Cells[3].Value.ToString() != "Pendente")
            {
                System.Windows.Forms.MessageBox.Show("Esta conta já foi paga, impossivel excluir a mesma!");
            }
            else
            {
                if (tipo == "Movel")
                {
                    int id;
                    id = Convert.ToInt16(dgvContas.CurrentRow.Cells[0].Value);
                    new ContasController().ExcluirMovel(id);

                    carregaLista(this.mes);
                }
                else
                {


                    List<ContaFixa> lstExclui = new ContasController().Listar(new ContaFixa());


                    for (int i = 0; i < lstExclui.Count; i++)
                    {
                        dgvContas.Rows.Add(
                           lstExclui[i].CodigoFixo,
                           lstExclui[i].Descricao,
                           lstExclui[i].DataVencimento,
                           lstExclui[i].DataPagamento,
                           lstExclui[i].numParcerlas,
                           lstExclui[i].Tipo,
                           lstExclui[i].Valor,
                           lstExclui[i].codigoConta

                           );

                        carregaLista(this.mes);

                        //exclui a conta fixa se estiver pendente
                        if (lstExclui[i].codigoConta == id_secundario && lstExclui[i].DataPagamento == "Pendente")
                        {
                            int id;
                            id = lstExclui[i].CodigoFixo;
                            new ContasController().ExcluirFixa(id);
                        }
                    }
                }
                System.Windows.Forms.MessageBox.Show("Conta excluída com sucessso!");
                carregaLista(this.mes);
            }
        }

        //pagar
        private void Pagar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("ATENÇÃO ao realizar o pagamento não será permitido nenhuma alteração!", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            // valida se o clique foi sim e recebe os valores
            if (confirm.ToString().ToUpper() == "YES")
            {


                String tipo = dgvContas.CurrentRow.Cells[5].Value.ToString();
                String status = dgvContas.CurrentRow.Cells[3].Value.ToString();
                String Zerado = dgvContas.CurrentRow.Cells[6].Value.ToString();

                if (Zerado == "")
                {
                    System.Windows.Forms.MessageBox.Show("Impossivel pagar conta com valor zero!");
                }
                else
                {

                    if (status == "Pendente")
                    {
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
                            ctaf1.codigoConta = Convert.ToInt16(dgvContas.CurrentRow.Cells[7].Value);

                            new ContasController().PagamentoMovel(ctaf1);
                            System.Windows.Forms.MessageBox.Show("Conta " + ctaf1.Descricao + " Paga com Sucesso");

                            carregaLista(this.mes);
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
                            ctaf.codigoConta = Convert.ToInt16(dgvContas.CurrentRow.Cells[7].Value);

                            new ContasController().Pagamento(ctaf);
                            MessageBox.Show("Conta " + ctaf.Descricao + " Paga com Sucesso");

                            carregaLista(this.mes);
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Esta conta já esta paga!");
                    }
                }
            }
            else
            {
                
            }
        }

        //Editar conta
        private void btn_edit_Click(object sender, EventArgs e)
        {
            

            if (dgvContas.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro");
            }
            else
            {
                ContaFixa ctaf = new ContaFixa();

                ctaf.DataPagamento = dgvContas.CurrentRow.Cells[3].Value.ToString();

                if (ctaf.DataPagamento == "Pendente")
                {
                    ctaf.CodigoFixo = Convert.ToInt16(dgvContas.CurrentRow.Cells[0].Value);
                    ctaf.Descricao = dgvContas.CurrentRow.Cells[1].Value.ToString();
                    ctaf.DataVencimento = dgvContas.CurrentRow.Cells[2].Value.ToString();
                    ctaf.numParcerlas = Convert.ToInt16(dgvContas.CurrentRow.Cells[4].Value);
                    ctaf.Valor = Convert.ToDouble(dgvContas.CurrentRow.Cells[6].Value);
                    ctaf.Tipo = dgvContas.CurrentRow.Cells[5].Value.ToString();
                    ctaf.codigoConta = Convert.ToInt16(dgvContas.CurrentRow.Cells[7].Value);

                    new frmEditConta(ctaf).ShowDialog();
                    carregaLista(this.mes);
                }
                else
                {
                    MessageBox.Show("Esta conta já esta paga!");
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //chama o cadastro de contas movel passando por parametro o mes selecionado
            new frmCadMovel(Convert.ToString(this.mes)).ShowDialog();
            carregaLista(mes);
        }

        private void btnCadFixa_Click(object sender, EventArgs e)
        {
            //chama o cadastro fixo passando por parametro o mes selecionado
            new frmCadFixo(Convert.ToString(this.mes)).ShowDialog();
            carregaLista(this.mes);
        }

        private void frmMes_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

            new frmCadRec(Convert.ToString(this.mes)).ShowDialog();
            carregaLista(this.mes);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtReceitasMes_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new frmReceitas(recMesPesquisa, anobusca, this.mes).ShowDialog();
            carregaLista(this.mes);
        }

        private void txtLiquidaMes_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Conexao().Fechar();
            Close();
        }

        private void textBoxPendentes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
