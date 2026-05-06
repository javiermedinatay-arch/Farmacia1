using Farmacia.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmRegistroProveedor nuevoFormulario = new FrmRegistroProveedor();
            nuevoFormulario.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmRegistroCompras nuevoFormulario = new FrmRegistroCompras();
            nuevoFormulario.Show();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmRegistroEmpleado nuevoFormulario = new FrmRegistroEmpleado();
            nuevoFormulario.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FrmUsuario nuevoFormulario = new FrmUsuario();
            nuevoFormulario.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmRegistroCompras nuevoFormulario = new FrmRegistroCompras();
            nuevoFormulario.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmProducto nuevoFormulario = new FrmProducto();
            nuevoFormulario.Show();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void BTNVENTA_Click(object sender, EventArgs e)
        {
            FrmRegistroVentas nuevoFormulario = new FrmRegistroVentas();
            nuevoFormulario.Show();
        }

        private void BTNSALIR_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Seguro que deseas salir?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
