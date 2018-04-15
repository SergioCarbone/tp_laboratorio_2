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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

            int aux;
            double Numero1, Numero2, resultado;
            string operacion = comboBox1.Text;
            if (int.TryParse(textNumero1.Text, out aux))
            {
                Numero1 = Convert.ToDouble(textNumero1.Text);
                if(int.TryParse(textNumero2.Text, out aux))
                {
                    Numero2 = Convert.ToDouble(textNumero2.Text);
                    if(operacion == "/" && Numero2 == 0)
                    {
                        lblResultado.Text = "Error!";
                    }
                    else
                    {
                        resultado = Entidades.Calculadora.Operar(Numero1, Numero2, operacion);
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
            lblResultado.Text = "";
            textNumero1.Text = "";
            textNumero2.Text = "";
            comboBox1.Text = "";
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
                lblResultado.Text = "No erea binario";
            }
        }

        private void textNumero1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textNumero2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
