using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dominio;
using Negocio;


namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        void cargarGrilla()
        {
            List<Articulo> articulos = new List<Articulo>();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                articulos = articuloNegocio.Listar();
                dataGridView1.DataSource = articulos;
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Imagen"].Visible = false;
                dataGridView1.Columns["Descripcion"].Visible = false;
                dataGridView1.Columns["Marca"].Visible = false;
                dataGridView1.Columns["Categoria"].Visible = false;
                RecargarImg(articulos[0].Imagen);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            Articulo seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.Imagen);
        }
        private void RecargarImg(string img)
        {
            try
            {
                pictureBox1.Load(img);
            }
            catch (Exception err)
            {
                pictureBox1.Load("http://anokha.world/images/not-found.png");

            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar agregar = new FormAgregar();
            agregar.ShowDialog();
            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Desea eliminar el articulo", "Eliminar articulo", MessageBoxButtons.YesNo);

            try
            {
                if (result == DialogResult.Yes)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    Articulo seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
                    articuloNegocio.Eliminar(seleccionado.Id);
                    MessageBox.Show("Articulo Eliminado");
                    cargarGrilla();
                }
            }
            catch (Exception err)
            {
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;

                FormModificar modificar = new FormModificar(seleccionado);
                modificar.ShowDialog();
                cargarGrilla();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dataGridView1.CurrentRow.DataBoundItem;
            FormDetalle Detalle = new FormDetalle(seleccionado);
            Detalle.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> articulos = new List<Articulo>();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                if (!(string.IsNullOrEmpty(txtBuscar.Text)))
                {
                    articulos = articuloNegocio.Filtrar(txtBuscar.Text);
                    dataGridView1.DataSource = articulos;
                }
                else
                {
                    cargarGrilla();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}

