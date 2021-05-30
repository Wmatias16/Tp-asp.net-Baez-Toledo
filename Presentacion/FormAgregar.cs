using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Presentacion
{
    public partial class FormAgregar : Form
    {

        public FormAgregar()
        {
            InitializeComponent();
        }

        public bool verificarText(List<TextBox> listBox)
        {
            bool verificado = true;

            foreach (TextBox txtBox in listBox)
            {
                if (string.IsNullOrEmpty(txtBox.Text))
                {
                    verificado = false;
                    txtBox.BackColor = Color.FromArgb(220, 53, 69);
                }
                else
                {
                    txtBox.BackColor = Color.DarkGray;
                }
            }


            return verificado;
        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {
            CategoriaNegocio listNegocio = new CategoriaNegocio();
            MarcaNegocio listMarca = new MarcaNegocio();
            try
            {
                BoxMarca.DataSource = listMarca.listar();
                BoxCategoria.DataSource = listNegocio.listar();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void bttAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            Articulo art = new Articulo();
            List<TextBox> listBox = new List<TextBox>();

            listBox.Add(txtCodigo);
            listBox.Add(txtNombre);
            listBox.Add(txtDescripcion);
            listBox.Add(txtPrecio);
            listBox.Add(txtImagen);

            DialogResult result = MessageBox.Show("Desea agregar el articulo", "Agregar articulo", MessageBoxButtons.YesNo);

            try
            {
                if (verificarText(listBox) && result == DialogResult.Yes)
                {
                    txtCodigo.Text = txtCodigo.Text.Replace(" ", String.Empty);

                    if (artNegocio.VerificarCodigo(txtCodigo.Text))
                    {
                        art.CodigoArticulo = txtCodigo.Text;
                        art.Nombre = txtNombre.Text;
                        art.Descripcion = txtDescripcion.Text;
                        art.Imagen = txtImagen.Text;
                        art.Precio = decimal.Parse(txtPrecio.Text);
                        art.Categoria = (Categoria)BoxCategoria.SelectedItem;
                        art.Marca = (Marca)BoxMarca.SelectedItem;

                        artNegocio.Agregar(art);
                        MessageBox.Show("Se agrego articulo");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error:El codigo articulo ya existe!");
                    }
                }
                else
                {
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Error: Faltan datos en el formulario");
                    }

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }


        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8)
                e.Handled = true;
        }

    }
}
