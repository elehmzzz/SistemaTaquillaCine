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
        // Precio base para el boleto estandar
        float precioEstandar = 85.00f;

        //cambia al seleccionar  un tipo de boleto
        private void cbmTipoBoleto_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoBoleto();
            txtExtra.Clear();
            lblTotalPagar.Text = "";
            lblTotalPagar.Text = "0.00";

        }

        // CAMBIO ALEXA: EVENTO DEL BOTÓN CALCULAR
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int indice = cbmTipoBoleto.SelectedIndex;
            string extra = txtExtra.Text.Trim();

            // Validar que el campo extra no esté vacío
            if (indice != 0 && string.IsNullOrEmpty(extra))
            {
                MessageBox.Show($"Ingresa el dato solicitado [{lblExtra.Text}]", "Validación");
                return;
            }

            clsBoleto boleto = null;
            lblTotalPagar.Text = calcularCostoBoleto(indice, boleto).ToString("#.##");
            //MessageBox.Show("Total a pagar: $" + totalPagar.ToString("0.00"), "Precio del Boleto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void tipoBoleto()
        {
            int indice = cbmTipoBoleto.SelectedIndex;
            lblCosto.Text = precioEstandar.ToString();
            switch (indice)
            {
                case 0://general
                    lblExtra.Visible = false;
                    txtExtra.Visible = false;
                    lblDescuento.Text = "0%";
                    break;
                case 1:
                    //adulto mayor
                    lblExtra.Visible = true;
                    lblExtra.Text = "No. del INAPAM:";
                    txtExtra.Visible = true;
                    lblDescuento.Text = "50%";
                    break;
                case 2:
                    //estudiante alexa
                    lblExtra.Visible = true;
                    lblExtra.Text = "Matricula:";
                    txtExtra.Visible = true;
                    lblDescuento.Text = "30%";
                    break;
            }

        }

        private float calcularCostoBoleto(int indice, clsBoleto boleto)
        {
            float totalPagar = 0;
            switch (indice)
            {
                case 0://general
                    boleto = new BoletoGeneral(precioEstandar);
                    break;
                case 1://adulto mayor
                    boleto = new BoletoAdultoMayor(precioEstandar, txtExtra.Text);
                    break;
                case 2://estudiante alexa
                    boleto = new BoletoEstudiante(precioEstandar, txtExtra.Text);
                    break;
            }
            totalPagar = boleto.calcularPrecioFinal();
            return totalPagar;

        }

    }
}
