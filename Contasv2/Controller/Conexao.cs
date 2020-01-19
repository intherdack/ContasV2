using MySql.Data.MySqlClient;
using System;

namespace Controller
{

    /// <summary>
    /// Classe de conexão com o MySQL
    /// </summary>
    public class Conexao
    {

        private MySqlConnection myConn;

        public Conexao()
        {
            myConn = new MySqlConnection("Server=contas-lucas.mysql.uhserver.com; Database=contas_lucas; Uid=rootlucas; Pwd='info.2008';");
        }// old guids=true Connection Timeout=60;  Port=3306;   SSl Mode=None;

        public void Abrir()
        {
            if (myConn.State != System.Data.ConnectionState.Open)
                myConn.Open();
        }

        public void Fechar()
        {
            if (myConn.State != System.Data.ConnectionState.Closed)
                myConn.Close();
        }

        public void Executar(MySqlCommand cmd)
        {

            try
            {
                cmd.Connection = myConn;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {  
                    case 1062: { throw new Exception("Este registro já está sendo utilizado."); }
                    case 1451: { throw new Exception("Atenção! Este registro não pode ser excluído no momento (chave estrangeira)."); }
                    default: { throw; }
                }
            }
            catch (Exception)
            {
                Fechar();
                throw;
            }

        }

        public MySqlDataReader Pesquisar(MySqlCommand cmd)
        {

            try
            {

                cmd.Connection = myConn;
                return cmd.ExecuteReader();

            }
            catch (Exception)
            {
                Fechar();
                throw;
            }

        }

    }
}
