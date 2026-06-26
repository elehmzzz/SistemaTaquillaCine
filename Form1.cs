using SistemaTaquillaCine.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaTaquillaCine.Clases;

namespace SistemaTaquillaCine
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        //metodo privado que carga el formulario
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cbmTipoBoleto.SelectedIndex = 0;
            lblCosto.Text = "80.00";
        }

        private void tipoBoleto() {
            int indice = cbmTipoBoleto.SelectedIndex;
            
            float precioBaseEstandar = 80.00f; // Precio base para el boleto estandar
            switch (indice) {
                case 0:
                    //general
                    lblExtra.Visible = false;
                    txtExtra.Visible = false;
                    lblDescuento.Visible = false; // CAMBIO ALEXA: OCULTA EL DESCUENTO

                    BoletoGeneral boletoG = new BoletoGeneral(precioBaseEstandar);

                    // 2. Calculamos el precio final y lo mostramos formateado con dos decimales
                    lblCosto.Text = boletoG.calcularPrecioFinal().ToString("0.00");

                    break;
                case 1:
                    //adulto mayor
                    lblExtra.Visible = true;
                    lblExtra.Text = "No. del INAPAM:";
                    txtExtra.Visible = true;
                    break;
                case 2:
                    //estudiante alexa
                    lblExtra.Visible = true;
                    lblExtra.Text = "Matricula:";
                    txtExtra.Visible = true;
                    lblDescuento.Visible = true; // CAMBIO ALEXA: MUESTRA EL DESCUENTO
                    lblDescuento.Text = "30% de descuento estudiante";                   
                    break;
            
            }
            
        }
        private void Calcularprecio()
        {
            int indice = cbmTipoBoleto.SelectedIndex;
            switch (indice)
            {
                case 1: // adulto mayor
                {
                        BoletoAdultoMayor adulto = new BoletoAdultoMayor(50, txtExtra.Text);
                        lblCosto.Text = adulto.calcularPrecioFinal().ToString();
                        break;
                }
                    
            }
            
        }
        private void cbmTipoBoleto_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoBoleto();
            Calcularprecio();
        }

        // CAMBIO ALEXA: EVENTO DEL BOTÓN CALCULAR
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            float precioBase = 80.00f;
            int indice = cbmTipoBoleto.SelectedIndex;
            string extra = txtExtra.Text.Trim();

            // Validar que el campo extra no esté vacío
            if (indice != 0 && string.IsNullOrEmpty(extra))
            {
                MessageBox.Show("Ingresa el dato solicitado (matrícula o INAPAM)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsBoleto boleto = null;

            if (indice == 0)
            {
                boleto = new BoletoGeneral(precioBase);
            }
            else if (indice == 1)
            {
                //boleto = new BoletoAdultoMayor(precioBase, extra);
            }
            else if (indice == 2)
            {
                boleto = new BoletoEstudiante(precioBase, extra);
            }

            float precioFinal = boleto.calcularPrecioFinal();
            lblCosto.Text = "$" + precioFinal.ToString("0.00");
            MessageBox.Show("Total a pagar: $" + precioFinal.ToString("0.00"), "Precio del Boleto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
