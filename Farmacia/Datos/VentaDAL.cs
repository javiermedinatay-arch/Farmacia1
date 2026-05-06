using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Farmacia.Entidades;

namespace Farmacia.Datos
{
    public class VentaDAL
    {
        // Instancia de tu clase de conexión
        Conexion cn = new Conexion();

        public bool RegistrarVenta(Venta obj, DataTable detalles)
        {
            bool respuesta = false;
            using (SqlConnection con = cn.GetConexion())
            {
                try
                {
                    // --- PASO CLAVE: Crear un clon con solo las columnas necesarias ---
                    DataTable dtParaEnvio = detalles.DefaultView.ToTable(false, "idproducto", "cantidad", "precio");
                    // Nota: Asegúrate de que el nombre "precio" coincida con la columna de tu dtCarrito

                    SqlCommand cmd = new SqlCommand("farm.usp_RegistrarVentaCompleta", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idcliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("@idempleado", obj.IdEmpleado);
                    cmd.Parameters.AddWithValue("@tipo_comprobante", obj.TipoComprobante);
                    cmd.Parameters.AddWithValue("@total_venta", obj.TotalVenta);
                    cmd.Parameters.AddWithValue("@metodo_pago", obj.MetodoPago);

                    // Enviamos el DataTable filtrado
                    SqlParameter paramDetalle = cmd.Parameters.AddWithValue("@detalles", dtParaEnvio);
                    paramDetalle.SqlDbType = SqlDbType.Structured;
                    paramDetalle.TypeName = "farm.DetalleVentaType";

                    con.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la capa de datos: " + ex.Message);
                }
            }
            return respuesta;
        }

        // Puedes mantener aquí los métodos para listar clientes o empleados si no creaste sus propios DAL
        public DataTable ListarClientes()
        {
            using (SqlConnection con = cn.GetConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM farm.vw_ListarClientes", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ListarEmpleados()
        {
            using (SqlConnection con = cn.GetConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM farm.vw_ListarEmpleados", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
