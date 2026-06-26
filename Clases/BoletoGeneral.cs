using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTaquillaCine.Clases
{
    internal class BoletoGeneral:clsBoleto
    {
        // El constructor ahora recibe y pasa un float a la clase base
        public BoletoGeneral(float precioBase) : base(precioBase)
        {
            // No requiere atributos adicionales
        }
        public override float calcularPrecioFinal()
        {
            // Retorna la variable protegida de la clase padre
            return precioBase;
        }
    }
}
