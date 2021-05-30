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
    public partial class FormModificar : Form
    {
        private Articulo art;

        public FormModificar(Articulo art)
        {
            InitializeComponent();

            this.art = art;
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

        private void FormModificar_Load(object sender, EventArgs e)
        {
            CategoriaNegocio listNegocio = new CategoriaNegocio();
            MarcaNegocio listMarca = new MarcaNegocio();
            try
            {
                BoxMarca.DataSource = listMarca.listar();
                BoxCategoria.DataSource = listNegocio.listar();

                txtCodigo.Text = this.art.CodigoArticulo;
                txtNombre.Text = this.art.Nombre;
                txtDescripcion.Text = this.art.Descripcion;
                txtImagen.Text = this.art.Imagen;
                txtPrecio.Text = this.art.Precio.ToString();
                BoxCategoria.SelectedItem = this.art.Categoria;
                BoxMarca.SelectedItem = this.art.Marca;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            List<TextBox> listBox = new List<TextBox>();

            listBox.Add(txtCodigo);
            listBox.Add(txtNombre);
            listBox.Add(txtDescripcion);
            listBox.Add(txtPrecio);
            listBox.Add(txtImagen);

            DialogResult result = MessageBox.Show("Desea modificar el articulo", "Modificar articulo", MessageBoxButtons.YesNo);

            try
            {
                if (verificarText(listBox) && result == DialogResult.Yes)
                {
                    if (art.CodigoArticulo == txtCodigo.Text || artNegocio.VerificarCodigo(txtCodigo.Text))
                    {
                        art.CodigoArticulo = txtCodigo.Text;
                        art.Nombre = txtNombre.Text;
                        art.Descripcion = txtDescripcion.Text;
                        art.Imagen = txtImagen.Text;
                        art.Precio = decimal.Parse(txtPrecio.Text);
                        art.Categoria = (Categoria)BoxCategoria.SelectedItem;
                        art.Marca = (Marca)BoxMarca.SelectedItem;



                        artNegocio.Modificar(art);
                        MessageBox.Show("Se modifico articulo");
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
    }
}
