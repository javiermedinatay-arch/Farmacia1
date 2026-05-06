using Farmacia.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia.Formularios
{
    public partial class FrmRegistroVentas : Form
    {
        // Instancias de la capa de datos
        VentaDAL ventaDAL = new VentaDAL();
        ProductoDAL productoDAL = new ProductoDAL();
        ClienteDAL clienteDAL = new ClienteDAL(); //
        EmpleadoDAL empleadoDAL = new EmpleadoDAL(); //
        DataTable dtCarrito = new DataTable();

        public FrmRegistroVentas()
        {
            InitializeComponent();
        }

        private void FrmRegistroVentas_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
