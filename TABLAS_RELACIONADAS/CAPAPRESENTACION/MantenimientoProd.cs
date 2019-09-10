using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TABLAS_RELACIONADAS.CAPADATOS;
namespace TABLAS_RELACIONADAS.CAPAPRESENTACION
{
    public partial class MantenimientoProd : Form
    {
        public MantenimientoProd()
        {
            InitializeComponent();
        }
        ClsProductos objproducto = new ClsProductos();
      public  string Operacion = "";
        public string idprod;

        public void ListarCategorias()
        {
            ClsProductos objProd = new ClsProductos();
            CmbCategoria.DataSource = objProd.ListarCategorias();
            CmbCategoria.DisplayMember = "CATEGORIA";
            CmbCategoria.ValueMember = "IDCATEG";
        }
        public void ListarMarcas()
        {
            ClsProductos objProd = new ClsProductos();
            CmbMarca.DataSource = objProd.ListarMarcas();
            CmbMarca.DisplayMember = "MARCA";
            CmbMarca.ValueMember = "IDMARCA";
        }

        private void MantenimientoProd_Load(object sender, EventArgs e)
        {
            //ListarCategorias();
            //ListarMarcas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objproducto._IdCategoria = Convert.ToInt32(CmbCategoria.SelectedValue);
                objproducto._IdMarca = Convert.ToInt32(CmbMarca.SelectedValue);
                objproducto._Descripcion = txtDescripcion.Text;
                objproducto._Precio = Convert.ToDouble(txtPrecio.Text);
                objproducto.InsertarProductos();

                MessageBox.Show("Se inserto correctamente");
            }
            else if (Operacion == "Editar")
            {
                objproducto._IdCategoria = Convert.ToInt32(CmbCategoria.SelectedValue);
                objproducto._IdMarca = Convert.ToInt32(CmbMarca.SelectedValue);
                objproducto._Descripcion = txtDescripcion.Text;
                objproducto._Precio = Convert.ToDouble(txtPrecio.Text);
                objproducto._Idprod = Convert.ToInt32(idprod);
                objproducto.EditarProductos();
                
                MessageBox.Show("Se edito correctamente");
                this.Close();
            }
        }

    }
}
