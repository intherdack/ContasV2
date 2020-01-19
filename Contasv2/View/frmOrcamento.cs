using Controller;
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
    public partial class frmOrcamento : System.Windows.Forms.Form
    {
        public frmOrcamento()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de janeiro
            frmMes janeiro = new frmMes();
            janeiro.carregaLista(1);
            janeiro.ShowDialog();
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de fevereiro
            frmMes fevereiro = new frmMes();
            fevereiro.carregaLista(2);
            fevereiro.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de marco
            frmMes marco = new frmMes();
            marco.carregaLista(3);
            marco.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de abril
            frmMes abril = new frmMes();
            abril.carregaLista(4);
            abril.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de maio
            frmMes maio = new frmMes();
            maio.carregaLista(5);
            maio.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de junho
            frmMes junho = new frmMes();
            junho.carregaLista(6);
            junho.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de julho
            frmMes julho = new frmMes();
            julho.carregaLista(7);
            julho.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de agosto
            frmMes agosto = new frmMes();
            agosto.carregaLista(8);
            agosto.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de setembro
            frmMes setembro = new frmMes();
            setembro.carregaLista(9);
            setembro.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de outubro
            frmMes outubro = new frmMes();
            outubro.carregaLista(10);
            outubro.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de novembro
            frmMes novembro = new frmMes();
            novembro.carregaLista(11);
            novembro.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            //estancia a tela para carregar o mes de dezembro
            frmMes dezembro = new frmMes();
            dezembro.carregaLista(12);
            dezembro.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_VisibleChanged(object sender, EventArgs e)
        {
             
        }

        private void textBox3_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox9_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox10_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox11_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox12_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox14_VisibleChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmOrcamento_Activated(object sender, EventArgs e)
        {
            //estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes janeiro = new frmMes();
            textBox1.Text = "R$ " + Convert.ToString(janeiro.carregaLista(1));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes fevereiro = new frmMes();
            textBox2.Text = "R$ " + Convert.ToString(fevereiro.carregaLista(2));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes marco = new frmMes();
            textBox3.Text = "R$ " + Convert.ToString(marco.carregaLista(3));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes abril = new frmMes();
            textBox4.Text = "R$ " + Convert.ToString(abril.carregaLista(4));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes maio = new frmMes();
            textBox6.Text = "R$ " + Convert.ToString(maio.carregaLista(5));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes junho = new frmMes();
            textBox7.Text = "R$ " + Convert.ToString(junho.carregaLista(6));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes julho = new frmMes();
            textBox8.Text = "R$ " + Convert.ToString(julho.carregaLista(7));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes agosto = new frmMes();
            textBox9.Text = "R$ " + Convert.ToString(agosto.carregaLista(8));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes setembro = new frmMes();
            textBox10.Text = "R$ " + Convert.ToString(setembro.carregaLista(9));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes outubro = new frmMes();
            textBox11.Text = "R$ " + Convert.ToString(outubro.carregaLista(10));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes novembro = new frmMes();
            textBox12.Text = "R$ " + Convert.ToString(novembro.carregaLista(11));

            // estancia a list para fazer a somoa e apresenta na tela de orçamento
            frmMes dezembro = new frmMes();
            textBox14.Text = "R$ " + Convert.ToString(dezembro.carregaLista(12));
        }
    }
}
