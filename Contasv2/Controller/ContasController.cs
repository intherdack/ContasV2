using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ContasController : Conexao
    {

        public void IncluirContaFixa(ContaFixa obj)
        {//cria um codigo alertorio para conta
            int um, dois, tres;
            um = Convert.ToInt32(DateTime.Today.DayOfYear);
            dois = obj.numParcerlas;
            tres = DateTime.Now.Millisecond;

            int hash = um + dois + tres;
            obj.codigoConta = hash;



            MySqlCommand cmd = new MySqlCommand("insert into contafixa values (default, @Descricao , @DataVencimento , @DataPagamento, @numParcerlas, @Valor, @Tipo, @codigoConta");


            cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("@DataVencimento", obj.DataVencimento);
            cmd.Parameters.AddWithValue("@DataPagamento", obj.DataPagamento);
            cmd.Parameters.AddWithValue("@numParcerlas", obj.numParcerlas);
            cmd.Parameters.AddWithValue("@Valor", obj.Valor);
            cmd.Parameters.AddWithValue("@Tipo", obj.Tipo);
            cmd.Parameters.AddWithValue("@codigoConta", obj.codigoConta);

            Abrir();
            Executar(cmd);
            Fechar();

        }

        public void IncluirContaMovel(ContaMovel obj)
        {
            //cria um codigo alertorio para conta
            int um, dois, tres;
            um = Convert.ToInt32(DateTime.Today.DayOfYear);
            dois = obj.numParcerlas;
            tres = DateTime.Now.Millisecond;

            int hash = um + dois + tres;
            obj.codigoConta = hash;

            MySqlCommand cmd = new MySqlCommand("insert into contamovel values (default, @Descricao , @DataVencimento , @DataPagamento, @numParcerlas, @Valor, @Tipo,  @codigoConta)");


            cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("@DataVencimento", obj.DataVencimento);
            cmd.Parameters.AddWithValue("@DataPagamento", obj.DataPagamento);
            cmd.Parameters.AddWithValue("@numParcerlas", obj.numParcerlas);
            cmd.Parameters.AddWithValue("@Valor", obj.Valor);
            cmd.Parameters.AddWithValue("@Tipo", obj.Tipo);
            cmd.Parameters.AddWithValue("@codigoConta", obj.codigoConta);
            Abrir();
            Executar(cmd);
            Fechar();

        }

        public List<ContaFixa> Listar(ContaFixa obj)
        {

            List<ContaFixa> lst = new List<ContaFixa>();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT * FROM contafixa union select * FROM contamovel";


            Abrir();

            MySqlDataReader reader = Pesquisar(cmd);

            while (reader.Read())
            {

                ContaFixa cf = new ContaFixa();

                cf.CodigoFixo = reader.GetInt32(0);
                cf.Descricao = reader.GetString(1);
                cf.DataVencimento = reader.GetString(2);
                cf.DataPagamento = reader.GetString(3);
                cf.numParcerlas = reader.GetInt32(4);
                cf.Valor = reader.GetDouble(5);
                cf.Tipo = reader.GetString(6);
                cf.codigoConta = reader.GetInt32(7);

                lst.Add(cf);

            }

            Fechar();

            return lst;

        }

        public void atualizaContaFixa(ContaFixa obj)
        {

            MySqlCommand cmd = new MySqlCommand("update contafixa set descricao = @Descricao, datavencimento = @DataVencimento, datapagamento = @DataPagamento, numparcelas = @numParcerlas, valor = @Valor, codigoConta = @codigoConta, tipo = @Tipo where codigo = @CodigoFixo");

            cmd.Parameters.AddWithValue("@CodigoFixo", obj.CodigoFixo);
            cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("@DataVencimento", obj.DataVencimento);
            cmd.Parameters.AddWithValue("@DataPagamento", obj.DataPagamento);
            cmd.Parameters.AddWithValue("@numParcerlas", obj.numParcerlas);
            cmd.Parameters.AddWithValue("@Valor", obj.Valor);
            cmd.Parameters.AddWithValue("@Tipo", obj.Tipo);
            cmd.Parameters.AddWithValue("@codigoConta", obj.codigoConta);

            Abrir();
            Executar(cmd);
            Fechar();


        }

        public void ExcluirFixa(int id)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM contafixa where codigo = @CodigoFixo");

            cmd.Parameters.AddWithValue("@CodigoFixo", id);
            Abrir();
            Executar(cmd);
            Fechar();


        }

        public void ExcluirMovel(int id)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM contamovel where codigo = @CodigoMovel");

            cmd.Parameters.AddWithValue("@CodigoMovel", id);
            Abrir();
            Executar(cmd);
            Fechar();


        }

        public void atualizaContaMovel(ContaMovel obj)
        {

            MySqlCommand cmd = new MySqlCommand("update contamovel set descricao = @Descricao, datavencimento = @DataVencimento, datapagamento = @DataPagamento, numparcelas = @numParcerlas, valor = @Valor, codigoConta = @codigoConta, tipo = @Tipo where codigo = @CodigoMovel");

            cmd.Parameters.AddWithValue("@CodigoMovel", obj.CodigoMovel);
            cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("@DataVencimento", obj.DataVencimento);
            cmd.Parameters.AddWithValue("@DataPagamento", obj.DataPagamento);
            cmd.Parameters.AddWithValue("@numParcerlas", obj.numParcerlas);
            cmd.Parameters.AddWithValue("@Valor", obj.Valor);
            cmd.Parameters.AddWithValue("@Tipo", obj.Tipo);
            cmd.Parameters.AddWithValue("@codigoConta", obj.codigoConta);
            Abrir();
            Executar(cmd);
            Fechar();


        }

        public void Pagamento(ContaFixa ctaf)
        {
            ctaf.DataPagamento = Convert.ToString(DateTime.Now); // atribui data de hoje  
            DateTime dataAux = Convert.ToDateTime(ctaf.DataVencimento); //converte data de vencimento em data

            new ContasController().atualizaContaFixa(ctaf);  //até aqui salva data de pagamento

            DateTime dataAux1 = Convert.ToDateTime(ctaf.DataVencimento); //auxiliar data vencimento

            if (ctaf.numParcerlas == 0 && dataAux1.Month == 12)//tipo conta mensal
            {
                String dia, mes;
                dia = dataAux1.Day.ToString();
                int ano = dataAux1.Year + 1;
                mes = 1.ToString();

                String auxfinal = dia + "/" + mes + "/" + ano;

                ctaf.DataVencimento = auxfinal;
                ctaf.DataPagamento = "Pendente";

                new ContasController().IncluirContinuo(ctaf); //já cria os registros do proximo ano para contas continuas
            }
            else
            {
                if (dataAux1.Month == 12 && ctaf.numParcerlas != 1)
                {
                    String dia, mes;
                    dia = dataAux1.Day.ToString();
                    int ano = dataAux1.Year + 1;
                    mes = 01.ToString();

                    String auxfinal = dia + "/" + mes + "/" + ano;

                    ctaf.DataVencimento = Convert.ToString(auxfinal);

                    ctaf.DataPagamento = "Pendente";
                    ctaf.numParcerlas = ctaf.numParcerlas - 1;

                    new ContasController().IncluirContaFixa(ctaf);

                }
            }

        }

        public void PagamentoMovel(ContaMovel ctaf1)
        {

            ctaf1.DataPagamento = Convert.ToString(DateTime.Now);

            DateTime dataAux = Convert.ToDateTime(ctaf1.DataVencimento);

            new ContasController().atualizaContaMovel(ctaf1);  //até aqui salva data de pagamento

        }

        public void IncluirContinuo(ContaFixa obj)
        {//cria um codigo alertorio para conta

            if (obj.codigoConta == 0)
            {
                int um, dois, tres;
                um = Convert.ToInt32(DateTime.Today.DayOfYear);
                dois = obj.numParcerlas;
                tres = DateTime.Now.Millisecond;

                int hash = um + dois + tres;
                obj.codigoConta = hash;
            }

            //caso seja primeiro registro ele cria hash senão herda 

            obj.Tipo = "Mensal";


            int sairWhile;

            String dia, mes, ano;
            do
            {

                DateTime dataAux = Convert.ToDateTime(obj.DataVencimento);

                dia = dataAux.Day.ToString();
                ano = dataAux.Year.ToString();
                mes = dataAux.Month.ToString();
                int aux2 = Convert.ToInt32(mes) + 1;

                String auxfinal = dia + "/" + aux2 + "/" + ano;

                sairWhile = aux2;

                MySqlCommand cmd = new MySqlCommand("insert into contafixa values (default, @Descricao , @DataVencimento , @DataPagamento, @numParcerlas, @Valor, @Tipo,  @codigoConta)");


                cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@DataVencimento", obj.DataVencimento);
                cmd.Parameters.AddWithValue("@DataPagamento", obj.DataPagamento);
                cmd.Parameters.AddWithValue("@numParcerlas", obj.numParcerlas);
                cmd.Parameters.AddWithValue("@Valor", obj.Valor);
                cmd.Parameters.AddWithValue("@Tipo", obj.Tipo);
                cmd.Parameters.AddWithValue("@codigoConta", obj.codigoConta);
                Abrir();
                Executar(cmd);




                obj.DataVencimento = Convert.ToString(auxfinal);



            } while (sairWhile < 13);

            
            Fechar();

        }

        public void IncluirConfParcelas(ContaFixa obj)
        {//cria um codigo alertorio para conta
            int um, dois, tres;
            um = Convert.ToInt32(DateTime.Today.DayOfYear);
            dois = obj.numParcerlas;
            tres = DateTime.Now.Millisecond;

            int hash = um + dois + tres;
            obj.codigoConta = hash;

            String auxfinal;

            int sairWhile = obj.numParcerlas;

            String dia, mes, ano;
            do
            {

                DateTime dataAux = Convert.ToDateTime(obj.DataVencimento);

                dia = dataAux.Day.ToString();
                ano = dataAux.Year.ToString();
                mes = dataAux.Month.ToString();
                int aux2 = Convert.ToInt32(mes) + 1;



                auxfinal = dia + "/" + aux2 + "/" + ano;



                MySqlCommand cmd = new MySqlCommand("insert into contafixa values (default, @Descricao , @DataVencimento , @DataPagamento, @numParcerlas, @Valor, @Tipo, @codigoConta)");


                cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@DataVencimento", obj.DataVencimento);
                cmd.Parameters.AddWithValue("@DataPagamento", obj.DataPagamento);
                cmd.Parameters.AddWithValue("@numParcerlas", obj.numParcerlas);
                cmd.Parameters.AddWithValue("@Valor", obj.Valor);
                cmd.Parameters.AddWithValue("@Tipo", obj.Tipo);
                cmd.Parameters.AddWithValue("@codigoConta", obj.codigoConta);
                Abrir();
                Executar(cmd);




                obj.numParcerlas = obj.numParcerlas - 1;

                if (mes == "12")// este if aumenta um ano quando parcelamento envouver mais de um ano
                {
                    int mes13 = Convert.ToInt32(ano);
                    mes13 = mes13 + 1;
                    ano = mes13.ToString();
                    //acima arrumo ano

                    mes = "01";

                    auxfinal = dia + "/" + mes + "/" + ano;

                }
                sairWhile--;
                obj.DataVencimento = Convert.ToString(auxfinal);


            } while (sairWhile > 0);

            
            Fechar();

        }

        public void IncluirRec(Receita rec)
        {

            MySqlCommand cmd = new MySqlCommand("insert into receita_contas values(default, @descricao, @valor, @data , @obs ,@codigoControle)");


            cmd.Parameters.AddWithValue("@valor", rec.Valor);
            cmd.Parameters.AddWithValue("@descricao", rec.Descricao);
            cmd.Parameters.AddWithValue("@data", rec.Data);
            cmd.Parameters.AddWithValue("@obs", rec.Obs);
            cmd.Parameters.AddWithValue("@codigoControle", rec.CodigoControle);

            Abrir();
            Executar(cmd);
            Fechar();
        }

        public List<Receita> BuscaReceitaMes(int mes, int ano)
        {
            List<Receita> lst = new List<Receita>();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT * FROM receita_contas";
            //cmd.Parameters.AddWithValue("@mes", mes);

            Abrir();

            MySqlDataReader reader = Pesquisar(cmd);

            double i = 0;

            while (reader.Read())
            {

                Receita r = new Receita();

                r.Codigo = reader.GetInt32(0);
                r.Descricao = reader.GetString(1);
                r.Valor = reader.GetDouble(2);
                r.Data = reader.GetString(3);
                r.Obs = reader.GetString(4);
                r.CodigoControle = reader.GetInt32(5);

                DateTime aux = Convert.ToDateTime(r.Data);

                if (aux.Month == mes && aux.Year == ano)
                {

                    lst.Add(r);
                    i = i + Convert.ToDouble(r.Valor);
                }
                if (lst.Count != 0)
                    lst[lst.Count - 1].soma = i;


            }

            Fechar();




            return lst;
        }
        public void AlterarRec(Receita rec)
        {

            MySqlCommand cmd = new MySqlCommand("update receita_contas set  descricao = @descricao, valor = @valor, data = @data, obs = @obs, codigoControle = @codigoControle where codigo = @codigo");

            cmd.Parameters.AddWithValue("@codigo", rec.Codigo);
            cmd.Parameters.AddWithValue("@valor", rec.Valor);
            cmd.Parameters.AddWithValue("@descricao", rec.Descricao);
            cmd.Parameters.AddWithValue("@data", rec.Data);
            cmd.Parameters.AddWithValue("@obs", rec.Obs);
            cmd.Parameters.AddWithValue("@codigoControle", rec.CodigoControle);

            Abrir();
            Executar(cmd);
            Fechar();
        }
        public void ExcluirRec(int id)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM receita_contas where codigoControle = @Codigo");

            cmd.Parameters.AddWithValue("@Codigo", id);
            Abrir();
            Executar(cmd);
            Fechar();


        }
        public void IncluirConfParcelasRec(Receita obj)
        {//cria um codigo alertorio para conta
            int um, dois, tres;
            um = Convert.ToInt32(DateTime.Today.DayOfYear);
            dois = Convert.ToInt32(DateTime.Today.DayOfWeek);
            tres = DateTime.Now.Millisecond;

            int hash = um + dois + tres;
            obj.CodigoControle = hash;

            String auxfinal;

            int sairWhile = Convert.ToInt32(obj.Obs);

            String dia, mes, ano;
            do
            {

                DateTime dataAux = Convert.ToDateTime(obj.Data);

                dia = dataAux.Day.ToString();
                ano = dataAux.Year.ToString();
                mes = dataAux.Month.ToString();
                int aux2 = Convert.ToInt32(mes) + 1;



                auxfinal = dia + "/" + aux2 + "/" + ano;



                MySqlCommand cmd = new MySqlCommand("insert into receita_contas values(default, @descricao, @valor, @data , @obs ,@codigoControle)");


                cmd.Parameters.AddWithValue("@valor", obj.Valor);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@data", obj.Data);
                cmd.Parameters.AddWithValue("@obs", obj.Obs);
                cmd.Parameters.AddWithValue("@codigoControle", obj.CodigoControle);
                Abrir();
                Executar(cmd);




                obj.Obs = (Convert.ToInt32(obj.Obs) - 1).ToString();

                if (mes == "12")// este if aumenta um ano quando parcelamento envouver mais de um ano
                {
                    int mes13 = Convert.ToInt32(ano);
                    mes13 = mes13 + 1;
                    ano = mes13.ToString();
                    //acima arrumo ano

                    mes = "01";

                    auxfinal = dia + "/" + mes + "/" + ano;

                }
                sairWhile--;
                obj.Data = Convert.ToString(auxfinal);


            } while (sairWhile > 0);

            Fechar();

        }
        public void IncluirContinuoRec(Receita obj)
        {//cria um codigo alertorio para conta

            if (obj.CodigoControle == 0)
            {
                int um, dois, tres;
                um = Convert.ToInt32(DateTime.Today.DayOfYear);
                dois = Convert.ToInt32(DateTime.Today.DayOfWeek);
                tres = DateTime.Now.Millisecond;

                int hash = um + dois + tres;
                obj.CodigoControle = hash;
            }

            //caso seja primeiro registro ele cria hash senão herda 

            obj.Obs = "Mensal";


            int sairWhile;

            String dia, mes, ano;
            do
            {

                DateTime dataAux = Convert.ToDateTime(obj.Data);

                dia = dataAux.Day.ToString();
                ano = dataAux.Year.ToString();
                mes = dataAux.Month.ToString();
                int aux2 = Convert.ToInt32(mes) + 1;

                String auxfinal = dia + "/" + aux2 + "/" + ano;

                sairWhile = aux2;

                MySqlCommand cmd = new MySqlCommand("insert into receita_contas values(default, @descricao, @valor, @data , @obs ,@codigoControle)");


                cmd.Parameters.AddWithValue("@valor", obj.Valor);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@data", obj.Data);
                cmd.Parameters.AddWithValue("@obs", obj.Obs);
                cmd.Parameters.AddWithValue("@codigoControle", obj.CodigoControle);
                Abrir();
                Executar(cmd);




                obj.Data = Convert.ToString(auxfinal);



            } while (sairWhile < 13);

            Fechar();

        }


    }
}