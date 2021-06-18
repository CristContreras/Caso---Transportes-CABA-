using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace UI
{
    public partial class Form1 : Form
    {
        Lista miLista;
        public Form1()
        {
            InitializeComponent();
            miLista = new Lista();

        }

        private void btnFormarFila_Click(object sender, EventArgs e)
        {
            int cant = txtDNI.TextLength;
            if (cant < 10)
            {
                MessageBox.Show("Debe ingresar su DNI de forma correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Text = "";
                txtDNI.Focus();
            }
            else
            {
                string dni = txtDNI.Text;
                char p1 = dni[2];
                char p2 = dni[6];
                int vp1 = p1;
                int vp2 = p2;
                int v = 0;
                if ((vp1 != 46) || (vp2 != 46))
                {
                    MessageBox.Show("Debe ingresar su DNI de forma correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    v = 1;
                    txtDNI.Text = "";
                    txtDNI.Focus();
                }
                if (v == 0)
                {
                    nodo unNodo = new nodo();
                    unNodo.Nombre = txtDNI.Text;
                    if (miLista.Primero == null)
                    {
                        miLista.Primero = unNodo;
                        miLista.Ultimo = unNodo;
                    }
                    else
                    {
                        miLista.Ultimo.Siguiente = unNodo;
                        miLista.Ultimo = unNodo;
                    }
                    miLista.Contador++;
                    txtDNI.Text = "";
                    txtDNI.Focus();
                    MessageBox.Show("Por favor aguarde en la fila a ser llamado y respete el distanciamiento social de 2 metros. Muchas gracias.", "Cuidémonos entre todos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void Mostrar()
        {
            listBox1.Items.Clear();
            if (miLista.Primero != null)
            {
                nodo otroNodo;
                otroNodo = miLista.Primero;
                listBox1.Items.Add(otroNodo.Nombre);
                while (otroNodo.Siguiente != null)
                {
                    otroNodo = otroNodo.Siguiente;
                    listBox1.Items.Add(otroNodo.Nombre);
                }
            }
            lblCantidad.Text = "Cant. Pasajeros: " + miLista.Contador.ToString();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnPermitir_Click(object sender, EventArgs e)
        {
            if (miLista.Primero != null)
            {
                MessageBox.Show("DNI: " + miLista.Primero.Nombre + " puede subir");
                nodo nodoActual = miLista.Primero.Siguiente;
                miLista.Primero = null;
                miLista.Primero = nodoActual;
                miLista.Contador--;
                Mostrar();
            }
            else
            {
                MessageBox.Show("No hay más DNI para permitir ascenso");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
