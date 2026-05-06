using Farmacia.Datos;
using Farmacia.Entidades;
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
        // Instancias de de acceso a datos y tabla temporal para el carrito
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
            ConfigurarCarrito();
            CargarComboBox();
        }
        private void ConfigurarCarrito()
        {
            if (dtCarrito.Columns.Count == 0)
            {
                dtCarrito.Columns.Add("idproducto", typeof(int));
                dtCarrito.Columns.Add("producto", typeof(string));
                dtCarrito.Columns.Add("precio", typeof(decimal));
                dtCarrito.Columns.Add("cantidad", typeof(int));
                dtCarrito.Columns.Add("subtotal", typeof(decimal));
            }
            dgv_venta.DataSource = dtCarrito;

            // Ocultar ID y ajustar diseño
            if (dgv_venta.Columns.Contains("idproducto")) dgv_venta.Columns["idproducto"].Visible = false;
            dgv_venta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarComboBox()
        {
            // Cargar ComboBoxes desde la DB
            cbo_cliente.DataSource = clienteDAL.ListarClientes();
            cbo_cliente.DisplayMember = "nombre_completo";
            cbo_cliente.ValueMember = "idcliente";

            cbo_empleado.DataSource = empleadoDAL.ListarEmpleados();
            cbo_empleado.DisplayMember = "nombre_completo";
            cbo_empleado.ValueMember = "idempleado";

            cbo_producto.DataSource = productoDAL.ListarProductos();
            cbo_producto.DisplayMember = "nombre_producto";
            cbo_producto.ValueMember = "idproducto";

            // Métodos de pago y comprobantes
            cbo_MetodoPago.Items.Clear();
            cbo_MetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta", "Yape/Plin" });

            cbo_TipoComprobante.Items.Clear();
            cbo_TipoComprobante.Items.AddRange(new string[] { "Boleta", "Factura" });
        }

        // -- Botón AGREGAR PRODUCTO -- 
        private void btn_agregarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_cantidad.Text))
            {
                MessageBox.Show("Ingrese una cantidad.");
                return;
            }

            int stockDisp = int.Parse(txt_stock.Text);
            int cantPedida = int.Parse(txt_cantidad.Text);

            if (cantPedida > stockDisp)
            {
                MessageBox.Show("No hay suficiente stock disponible.");
                return;
            }

            // Calculamos subtotal
            decimal precio = decimal.Parse(txt_precioUni.Text);
            decimal subtotal = cantPedida * precio;

            // Añadimos al DataGridView (a través del DataTable)
            dtCarrito.Rows.Add(
                cbo_producto.SelectedValue,
                cbo_producto.Text,
                precio,
                cantPedida,
                subtotal
            );

            CalcularTotales();
            txt_cantidad.Clear();
        }

        // -- Botón ELIMINAR PRODUCTO -- 
        private void btn_EliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgv_venta.CurrentRow != null)
            {
                // Elimina la fila seleccionada del carrito
                dgv_venta.Rows.RemoveAt(dgv_venta.CurrentRow.Index);
                CalcularTotales();
            }
        }
        private void CalcularTotales()
        {
            decimal total = 0;
            foreach (DataRow row in dtCarrito.Rows)
            {
                total += Convert.ToDecimal(row["subtotal"]);
            }

            // Suponiendo que el subtotal es antes de impuestos o igual si ya incluye IGV
            txt_Subtotal.Text = total.ToString("N2");
            txt_TotalFinal.Text = total.ToString("N2");
        }

        // -- Botón CONFIRMAR PRODUCTO -- 
        private void btn_confirmarVenta_Click(object sender, EventArgs e)
        {
            if (dtCarrito.Rows.Count == 0) { MessageBox.Show("El carrito está vacío."); return; }
            if (cbo_MetodoPago.SelectedIndex == -1) { MessageBox.Show("Seleccione método de pago."); return; }

            try
            {
                Venta venta = new Venta()
                {
                    IdCliente = (int)cbo_cliente.SelectedValue,
                    IdEmpleado = (int)cbo_empleado.SelectedValue,
                    TipoComprobante = cbo_TipoComprobante.Text,
                    TotalVenta = decimal.Parse(txt_TotalFinal.Text),
                    MetodoPago = cbo_MetodoPago.Text
                };

                if (ventaDAL.RegistrarVenta(venta, dtCarrito))
                {
                    MessageBox.Show("¡Venta realizada con éxito!");
                    LimpiarFormulario();
                    CargarComboBox(); // Refrescar stocks
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al confirmar: " + ex.Message);
            }
        }
        private void LimpiarFormulario()
        {
            dtCarrito.Clear();
            txt_cantidad.Clear();
            txt_Subtotal.Clear();
            txt_TotalFinal.Clear();
            cbo_MetodoPago.SelectedIndex = -1;
            cbo_TipoComprobante.SelectedIndex = -1;
        }
        private void btn_cancelarVenta_Click(object sender, EventArgs e)
        {
            // Limpiamos el DataTable del carrito para volver a vender
            dtCarrito.Clear();

            // Volvemos a enlazar el DataSource al carrito vacío
            dgv_venta.DataSource = dtCarrito;

            // Limpiamos los campos de texto
            LimpiarFormulario();
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

        private void cbo_empleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbo_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_precioUni_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_stock_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_crearCliente_Click(object sender, EventArgs e)
        {

        }

        private void btn_crearProducto_Click(object sender, EventArgs e)
        {

        }

        private void dgv_venta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_Subtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_TotalFinal_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbo_MetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbo_TipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbo_productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al seleccionar producto, mostramos su precio y stock actual
            if (cbo_producto.SelectedValue != null && cbo_producto.SelectedItem is DataRowView row)
            {
                txt_precioUni.Text = row["precio_venta"].ToString();
                txt_stock.Text = row["stock_actual"].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Cambiamos el DataSource del DataGridView para mostrar el historial
                DataTable dtHistorial = ventaDAL.ListarVentasRealizadas();

                if (dtHistorial.Rows.Count > 0)
                {
                    dgv_venta.DataSource = dtHistorial;
                    MessageBox.Show("Mostrando historial de ventas recientes.");
                }
                else
                {
                    MessageBox.Show("No hay ventas registradas para mostrar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle: " + ex.Message);
            }
        }
    }
    }
}
