using SistemaTaquillaCine.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTaquillaCine.Clases
{
    internal class BoletoAdultoMayor: clsBoleto
    {
        public string Numcredencial { get; set; }
        public BoletoAdultoMayor( float precioBase,string credencial): base (precioBase)
        {
            Numcredencial= credencial;
        }

        public override float calcularPrecioFinal()
        {
            return  precioBase * 0.5f;
        }
    }
}
