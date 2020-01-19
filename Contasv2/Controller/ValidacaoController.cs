using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contasv2.Controller
{
    public class ValidacaoController
    {
        public Double CorrigeDouble(String var)
        {

            // Instancia o StringBuilder
            StringBuilder sb = new StringBuilder(var);

            // Remove 1 (um) caracter a partir do índice 0 (zero)
            int local = var.IndexOf('.');

            if (local < 0)
            {
                Double Correcao2 = Convert.ToDouble(var);

                return Correcao2;
            }
            else
            {
                sb.Remove(local, 1);
                sb.Insert(local, ",");
            }
        
        // Obtém a string modificada
        string Correcao1 = sb.ToString();


            Double Correcao = Convert.ToDouble(Correcao1);
            return Correcao;

        }
    }
}
