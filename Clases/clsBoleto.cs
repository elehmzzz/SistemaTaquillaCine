using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTaquillaCine.Clases
{
    internal abstract class clsBoleto
    {
        protected float precioBase;
        
        //constructor
        public clsBoleto(float precioBase) {
            this.precioBase = precioBase;
        }

        public abstract float calcularPrecioFinal();
        

    }
}
