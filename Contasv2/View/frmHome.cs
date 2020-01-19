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
    public partial class frmHome : System.Windows.Forms.Form
    {
        
        DateTime dataVenci;
        String anobusca;
        double valorTotal = 0;
        double pendencias = 0;
        

        //deve.Text = "R$ " + Convert.ToString(pendencias);

        private void frmPaginaInicial_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes atual
            DateTime ano = DateTime.Today;
            int ano2 = Convert.ToInt16(ano.Month);
            frmMes mesAtual = new frmMes();
            mesAtual.carregaLista(ano2);
            mesAtual.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new frmOrcamento().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Conexao().Fechar();
            Close();
        }

        private void deve_Click(object sender, EventArgs e)
        {
            List<ContaFixa> lst = new ContasController().Listar(new ContaFixa());

            for (int i = 0; i < lst.Count; i++)
            {
                dataVenci = Convert.ToDateTime(lst[i].DataVencimento);
                String ano = Convert.ToString(DateTime.Now.Year);
                String dataAux2 = Convert.ToString(dataVenci.Year);


                anobusca = ano;
                String mesPesquisa = DateTime.Now.Month.ToString();


                if (dataVenci.Month.ToString() == mesPesquisa)
                { //valida se a conta pertence ao mes de janeiro

                    if (anobusca == dataAux2)//Valida ano de busca
                    {
                        valorTotal = lst[i].Valor + valorTotal;

                        if (lst[i].DataPagamento == "Pendente")
                        {
                            pendencias = lst[i].Valor + pendencias;
                        }

                    }
                }
            }
            if (pendencias != null)
            {
                textPendencia.Text = "Bem vindo Proencio, você possui conta em atraso.";
            }
            else
            {
                textPendencia.Text = "Bem vindo Proencio, você não possui conta em atraso.";
            }

            Console.WriteLine(pendencias);
        }
    }
}
