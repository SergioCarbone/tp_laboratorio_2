using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades_;
using System.IO;
using System.Data.SqlClient;


namespace MainCorreo
{
    public partial class Form1 : Form
    {
        Correo correo;
        public Form1()
        {
            InitializeComponent();
            correo = new Correo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {
                    AgregarPaquete(textBox1.Text, maskedTextBox2.Text);
                }
            }
            catch (TrackingIdRepetidoException s)
            {

                MessageBox.Show(s.Message, "Error");
            }
        }


        private void AgregarPaquete(string direccion, string trackingID)
        {
            Paquete paquete = new Paquete(direccion, trackingID);
            paquete.InformarEstado += paq_InformaEstado;

            correo += paquete;
        }


        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.MiDelegadoEstado d = new Paquete.MiDelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }


        public void ActualizarEstados()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        listBox1.Items.Add(item);                     
                        break;
                    case Paquete.EEstado.EnViaje:
                        listBox2.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;
                }                
            }            
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);            
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.ReferenceEquals(elemento, null))
            {
                richTextBox1.Text = elemento.MostrarDatos(elemento);
                elemento.MostrarDatos(elemento).Guardar("salida.txt");
            }
        }

        private void btnMostrarTodos_Click_1(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lstEstadoEntregado.ContextMenuStrip = contextMenuStrip1;
        }
    }
}
