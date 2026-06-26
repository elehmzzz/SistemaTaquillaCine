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
            lblCosto.Text = "50.00";
        }

        private void tipoBoleto() {
            int indice = cbmTipoBoleto.SelectedIndex;
            switch (indice)
            {
                case 0:
                    //general
                    lblExtra.Visible = false;
                    txtExtra.Visible = false;
                    break;
                case 1:
                    //adulto mayor
                    lblExtra.Visible = true;
                    lblExtra.Text = "No. del INAPAM:";
                    txtExtra.Visible = true;
                    break;
                case 2:
                    //estudiante
                    lblExtra.Visible = true;
                    lblExtra.Text = "Matricula:";
                    txtExtra.Visible = true;
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
        
    }
}
