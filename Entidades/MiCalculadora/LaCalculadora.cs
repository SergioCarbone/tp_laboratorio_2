using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }


        private void btnOperar_Click(object sender, EventArgs e)
        {

            double aux;
            double resultado;
            string operacion = comboBox1.Text;
            if (double.TryParse(textNumero1.Text, out aux))
            {
                if(double.TryParse(textNumero2.Text, out aux))
                {
                    if(operacion == "/" && textNumero2.Text == "0")
                    {
                        lblResultado.Text = "Op. no válida";
                        
                    }
                    else
                    {
                        resultado = Operar(textNumero1.Text, textNumero2.Text, operacion);
                        lblResultado.Text = resultado.ToString();
                    }
                }
                else
                {
                    lblResultado.Text = "ERROR!";
                }
            }
            else
            {
                lblResultado.Text = "ERROR!";
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void btnConvABinario_Click(object sender, EventArgs e)
        {
            string numDecimal;
            double numero = Convert.ToDouble(lblResultado.Text);
            if(numero >= 0)
            {
                numDecimal =  Entidades.Numero.DecimalBinario(numero);
                lblResultado.Text = numDecimal.ToString();
            }
        }

        private void btnConvADecimal_Click(object sender, EventArgs e)
        {
            double numero;
            numero = Entidades.Numero.BinarioDecimal(lblResultado.Text);

            if(numero != -1)
            {
                lblResultado.Text = numero.ToString();
            }
            else
            {
                lblResultado.Text = "No erea\n binario";
            }
        }


        public void Limpiar()
        {
            lblResultado.Text = "";
            textNumero1.Text = "";
            textNumero2.Text = "";
            comboBox1.Text = "";
        }


        private static double Operar(string valor1, string valor2, string operador)
        {
            double numero1 = Convert.ToDouble(valor1);
            double numero2 = Convert.ToDouble(valor2);
            double resultado = Entidades.Calculadora.Operar(numero1, numero2, operador);

            return resultado;
        }

    }
}
