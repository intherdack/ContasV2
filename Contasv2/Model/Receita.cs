using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Receita
    {
        public int Codigo { get; set; }
        public String Descricao { get; set; }
        public Double Valor { get; set; }
        public String Data { get; set; }
        public String Obs { get; set; }
        public int CodigoControle { get; set; }
        public double soma { get; set; }
    }
}
