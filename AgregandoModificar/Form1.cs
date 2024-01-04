using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
    

namespace AgregandoModificar
{
    public partial class Form1 : Form
    {

        GestorCliente gestorCliente;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                  if (openFileDialog.ShowDialog()==DialogResult.OK) 
                {
                    gestorCliente=new GestorCliente(openFileDialog.FileName);
                    lblArchivoSelec.Text=openFileDialog.FileName;
                    btnAgregar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnCargar.Enabled = false;
                    btnModificar.Enabled = true;
                    MostrarLista();

                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Error al cargar!","Verificar entradas",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarNombre(txtNombre.Text)&& ValidarNumero(txtNumero.Text) && ValidarNumero(txtPrecio.Text))
                {
                    Cliente unCliente = new Cliente();
                    unCliente.Numero = Convert.ToInt32(txtNumero.Text);
                    unCliente.Precio = Convert.ToDecimal(txtPrecio.Text);
                    unCliente.Nombre = txtNombre.Text;
                    gestorCliente.RegistrarCliente(unCliente);
                    MostrarLista();

                }
                else
                {
                    MessageBox.Show("Error en la entrada de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            catch (Exception)
            {
                MessageBox.Show("Error al agregar!", "Verificar entradas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ValidarNombre(string linea)
        {
            return Regex.IsMatch(linea, @"^[a-zA-Z]+$");
        }
        public static bool ValidarNumero(string linea)
        {
            return Regex.IsMatch(linea, @"^[0-9]+$");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count>0) 
            {
                Cliente unCliente = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;
                gestorCliente.EliminarCliente(unCliente.Numero);
                MostrarLista();
            }
            else
            {
                MessageBox.Show("No hay elementos en la lista o no ha seleccionado ninguno.", "Chequear", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void MostrarLista()
        {
            dgvClientes.DataSource = gestorCliente.ListarClientes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {

                if (ValidarNombre(txtNombre.Text) && ValidarNumero(txtNumero.Text) && ValidarNumero(txtPrecio.Text))
                {

                   
                    Cliente unClienteModificado = new Cliente();
                    unClienteModificado.Numero = Convert.ToInt32(txtNumero.Text);
                    unClienteModificado.Precio = Convert.ToDecimal(txtPrecio.Text);
                    unClienteModificado.Nombre = txtNombre.Text;
                    Cliente unCliente = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;
                    gestorCliente.ModificarCliente(unCliente.Numero,unClienteModificado);
                    MostrarLista();
                }
                else
                {
                    MessageBox.Show("Error en la entrada de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay elementos en la lista o no ha seleccionado ninguno.", "Chequear", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }

                
            }

    }
}
