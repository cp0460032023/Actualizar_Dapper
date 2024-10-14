using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actualizar_Categoría
{
    public partial class Form1 : Form
    {
        RepositorioCategoria CategoriaR=new RepositorioCategoria();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            var cat = CategoriaR.ObtenerTodo();
            DGV_CATEGORÍA.DataSource = cat;
        }

        private void btnBuscarID_Click(object sender, EventArgs e) // Se utilizó TryParse para recibir datos en String y no en INT.
        {
            if (int.TryParse(txtBuscarID.Text, out int id))
            {

                var cat = CategoriaR.ObtenerPoeID(id);
                DGV_CATEGORÍA.DataSource = new List<Categorias> { cat };
                
                if (cat != null) { RellenarEspacios(cat); }
                
            }
            else
            {

                MessageBox.Show(" Por favor Ingrese un ID Existente .");
            }
        }

        private void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            var CateUpdate = CrearCate();
            var Actualizada = CategoriaR.ActualizarCategoria(CateUpdate);
            MessageBox.Show($"Se ha Actualizado: {Actualizada}");

        }
        private Categorias CrearCate()
        {
            var nueva = new Categorias
            {
                CategoryID = int.Parse(txtCategoríaID.Text),
                CategoryName =txtNameCat.Text,
                Description = txtDescripcion.Text
            };
            return nueva;
        }

        private void RellenarEspacios(Categorias categoria)
        {
            txtCategoríaID.Text = categoria.CategoryID.ToString();
            txtNameCat.Text = categoria.CategoryName;
            txtDescripcion.Text = categoria.Description;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
