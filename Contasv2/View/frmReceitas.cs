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
    public partial class frmReceitas : Form
    {
        List<Receita> lstRec1 = new List<Receita>();
        
        int auxmesPesquisa, auxMes;
        String auxAno;
        public frmReceitas(int mespesquisa, string ano,int mes)
        {
            InitializeComponent();
            carrega(mespesquisa, ano, mes);
            auxmesPesquisa = mespesquisa;
            auxMes = mes;
            auxAno = ano;

        }

        private void frmReceitas_Load(object sender, EventArgs e)
        {

        }
        public void carrega(int mespesquisa, string ano, int mes)
        {
            switch (mes)
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

            lstRec1 = new ContasController().BuscaReceitaMes(mespesquisa, Convert.ToInt32(ano));

            dgvRec.Rows.Clear();

            if (lstRec1.Count != 0)
            {
                for (int i = 0; i < lstRec1.Count; i++)
                {
                    dgvRec.Rows.Add(
                             lstRec1[i].Codigo,
                             lstRec1[i].Descricao,
                             lstRec1[i].Valor,
                             lstRec1[i].Data,
                             lstRec1[i].Obs,
                             lstRec1[i].CodigoControle);

                }
                txtReceitas.Text = "R$ " + Convert.ToString(lstRec1[lstRec1.Count() - 1].soma);
                txtReceitas.Enabled = false;
            }
            else
            {
                txtReceitas.Text = "Sem Cadastro";
                txtReceitas.Enabled = false;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dgvRec.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro");
            }
            else
            {
                Receita alterar = new Receita();

                alterar.Codigo = Convert.ToInt32(dgvRec.CurrentRow.Cells[0].Value);
                alterar.Descricao = dgvRec.CurrentRow.Cells[1].Value.ToString();
                alterar.Valor = Convert.ToDouble(dgvRec.CurrentRow.Cells[2].Value);
                alterar.Data = dgvRec.CurrentRow.Cells[3].Value.ToString();
                alterar.Obs = dgvRec.CurrentRow.Cells[4].Value.ToString();
                alterar.CodigoControle = Convert.ToInt32(dgvRec.CurrentRow.Cells[5].Value);

                new frmEditRec(alterar).ShowDialog();
            }
            carrega(auxmesPesquisa, auxAno, auxMes);

            
        }

        private void frmReceitas_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void frmReceitas_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void frmReceitas_ControlRemoved(object sender, ControlEventArgs e)
        {
          
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvRec.CurrentRow == null)
            {
                MessageBox.Show("Selecione um registro");
            }
            else
            {
                //salva sim o não para alterar
                DialogResult confirm = MessageBox.Show("ATENÇÃO a receita será excluída de todos os meses cadastrados, Deseja continuar?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                // valida se o clique foi sim e recebe os valores
                if (confirm.ToString().ToUpper() == "YES")
                {
                    new ContasController().ExcluirRec(Convert.ToInt32(dgvRec.CurrentRow.Cells[5].Value));
                    MessageBox.Show("Excluido com Sucesso");
                    carrega(auxmesPesquisa, auxAno, auxMes);
                }
                else
                {
                    MessageBox.Show("Operação Cancelada pelo Usuário");
                }
            }

        }

        private void anoBusca_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRel_Click(object sender, EventArgs e)
        {
            if (auxmesPesquisa != 0 && anoBusca.Text.Trim() != "" && auxMes != 0)
            {
                carrega(auxmesPesquisa, anoBusca.Text, auxMes);
            }
            else
            {
                DateTime aux = DateTime.UtcNow;
                auxmesPesquisa = aux.Day;
                anoBusca.Text = aux.Year.ToString();
                auxMes = aux.Month;

                carrega(auxmesPesquisa, anoBusca.Text, auxMes);

            }
        }



    }
}
