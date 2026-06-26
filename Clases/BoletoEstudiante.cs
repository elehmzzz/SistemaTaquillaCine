using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTaquillaCine.Clases
{
    internal class BoletoEstudiante: clsBoleto
    {
        // Guarda la matrícula del estudiante
        private string matricula;

        // Permite ver y cambiar la matrícula desde fuera
        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        // Constructor: guarda la matrícula y manda el precio a la clase padre
        public BoletoEstudiante(float precioBase, string matricula) : base(precioBase)
        {
            this.matricula = matricula;
        }

        // Calcula el precio final (descuento del 30%)
        public override float calcularPrecioFinal()
        {
            return precioBase * 0.70f;  // 70% del precio original
        }

        // Devuelve la información del boleto como texto
        public override string ToString()
        {
            return "Boleto Estudiante - Matrícula: " + matricula + " - Precio: $" + calcularPrecioFinal();
        }
    }
}
