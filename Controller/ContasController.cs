using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ContasController : Conexao
    {

        public void IncluirContaFixa(ContaFixa obj)
        {

            MySqlCommand cmd = new MySqlCommand("insert into ContaFixa values default, @Descricao, @DataVencimento, @DataPagamento");


            cmd.Parameters.AddWithValue("@chassi", obj.Descricao);
            cmd.Parameters.AddWithValue("@placa", obj.DataVencimento);
            cmd.Parameters.AddWithValue("@renavan", obj.DataPagamento);

            Abrir();
            Executar(cmd);
            Fechar();

        }

        public List<ContaFixa> Listar(ContaFixa obj)
        {

            List<ContaFixa> lst = new List<ContaFixa>();
            List<ContaMovel> contaMovel = new List<ContaMovel>();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "select ";
            cmd.CommandText += " cf.CodigoFixo, ";
            cmd.CommandText += " cf.Descricao, ";
            cmd.CommandText += " cf.DataVencimento, ";
            cmd.CommandText += " cf.DataPagamento, ";
            cmd.CommandText += " cm.CodigoMovel, ";
            cmd.CommandText += " cm.Descricao, ";
            cmd.CommandText += " cm.DataVencimento, ";
            cmd.CommandText += " cm.DataPagamento, ";

            cmd.CommandText += " from ";

            cmd.CommandText += " ContaFixa cf, ";
            cmd.CommandText += " ContaMovel cm ";
            // cmd.CommandText += " where ";
            // cmd.CommandText += " au.codCor = cor.codCor ";
            // cmd.CommandText += " and au.codModelo = mo.codModelo ";
            //cmd.CommandText += " and mo.codMarca = ma.codMarca ";



            // cmd.CommandText += " order by au.codAutomovel asc ";

            Abrir();



            Fechar();

            return lst;

        }
    }

}