using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ContaFixa
    {
        public int CodigoFixo { get; set; }
        public String Descricao { get; set; }
        public String DataVencimento { get; set; }
        public String DataPagamento { get; set; }
        public int numParcerlas { get; set; }
        public double Valor { get; set; }
        public String Tipo { get; set; } = "Fixo";
        public int codigoConta { get; set; }



    }
}
