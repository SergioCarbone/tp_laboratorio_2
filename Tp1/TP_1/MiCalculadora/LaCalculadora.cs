using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Borra el texto de los Label y borra los iconos de maximizar y minimizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaCalculadora_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        /// <summary>
        /// Toma los valores ingresados si son correctos, caso contrario da mendase de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador = comboBox1.Text;
            double num1, num2, resultado;

            if(double.TryParse(textBox1.Text, out num1))
            {
                label2.Text = "";
                if(double.TryParse(textBox2.Text, out num2))
                {
                    if(operador == "/" && textBox2.Text == "0")
                    {
                        label1.Text = "Error";
                        MessageBox.Show("No se puede dividir por 0", "Error", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                    }
                    else
                    {
                        resultado = Operar(textBox1.Text, textBox2.Text, operador);
                        label1.Text = resultado.ToString();
                    }
                }
                else
                {                    
                    MessageBox.Show("Error, ingrese un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
            }
            else
            {
                MessageBox.Show("Error, ingrese un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Realiza un operacion entre dos valores y un operador
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string num1, string num2, string operador)
        {
            double valor1 = Convert.ToDouble(num1);
            double valor2 = Convert.ToDouble(num2);
            Numero aux1 = new Numero(valor1);
            Numero aux2 = new Numero(valor2);

            return Calculadora.Operar(aux1, aux2, operador);            
        }


        /// <summary>
        /// Llama al metodo limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        /// <summary>
        /// Borra el texto de los campos
        /// </summary>
        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label1.Text = "";
            label2.Text = "";
            comboBox1.Text = "";
        }

        /// <summary>
        /// Cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        /// <summary>
        /// Inicia la conversion de un valor decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            double aux;
            string resultado, valor;

            valor = label1.Text;
            if(valor == "")
            {
                aux = Convert.ToDouble(textBox1.Text);
            }
            else
            {
                aux = Convert.ToDouble(label1.Text);
            }
           
            if (aux > 0)
            {
                resultado = Numero.DecimalBinario(aux);
                if (resultado == "Valor invalido")
                {
                    label1.Text = "";
                    label2.Text = resultado;
                }
                else
                {
                    label2.Text = "";
                    label1.Text = resultado;
                }
            }
            else
            {
                label2.Text = "Valor invalido";
            }
        }


        /// <summary>
        /// Inicia la conversion de un valor binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string valor = label1.Text, resultado;

            if(valor == "")
            {
                resultado = Numero.BinarioDecimal(textBox1.Text);
            }
            else
            {
                resultado = Numero.BinarioDecimal(label1.Text);
            }
             
            
            if (resultado == "Valor invalido")
            {
                label1.Text = "";
                label2.Text = resultado;
            }
            else
            {
                label1.Text = resultado;
            }            
        }


    }
}
