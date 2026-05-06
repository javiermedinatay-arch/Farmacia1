using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Datos
{
    public class ProductoDAL
    {
        Conexion cn = new Conexion();

        // Para llenar el ComboBox de Productos
        public DataTable ListarProductos()
        {
            using (SqlConnection con = cn.GetConexion())
            {
                // Usamos la vista que creamos anteriormente
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM farm.vw_ListarProductos", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Método opcional para buscar por nombre si lo necesitas
        public DataTable BuscarProducto(string texto)
        {
            using (SqlConnection con = cn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM farm.vw_ListarProductos WHERE nombre_producto LIKE @texto + '%'", con);
                cmd.Parameters.AddWithValue("@texto", texto);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
