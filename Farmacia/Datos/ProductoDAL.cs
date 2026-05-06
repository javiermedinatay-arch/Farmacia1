using Farmacia.Entidades;
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

        // 1. Listar productos (Usando la vista)
        public DataTable ListarProductos()
        {
            using (SqlConnection con = cn.GetConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM farm.vw_ListarProductos", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Buscar producto (Siguiendo el formato de procedimiento almacenado del profesor)
        public DataTable BuscarProducto(string texto)
        {
            using (SqlConnection con = cn.GetConexion())
            {
                // Es mejor usar un SP para mantener la lógica en la base de datos
                SqlCommand cmd = new SqlCommand("farm.sp_BuscarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TextoBusqueda", texto);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 3. Insertar Producto (Réplica del formato sp_InsertarDocente)
        public string InsertarProducto(Producto p)
        {
            using (SqlConnection con = cn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("farm.sp_InsertarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", p.NombreProducto);
                // Manejo de nulos para descripción y fecha de vencimiento
                cmd.Parameters.AddWithValue("@Descripcion", (object)p.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", p.PrecioVenta);
                cmd.Parameters.AddWithValue("@Stock", p.StockActual);
                cmd.Parameters.AddWithValue("@FechaVencimiento", (object)p.FechaVencimiento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Laboratorio", p.Laboratorio);
                cmd.Parameters.AddWithValue("@IdCategoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@IdMarca", p.IdMarca);
                cmd.Parameters.AddWithValue("@IdUnidad", p.IdUnidadMedida);

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Error al insertar";
            }
        }

        // 4. Actualizar Producto
        public string ActualizarProducto(Producto p)
        {
            using (SqlConnection con = cn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("farm.sp_ModificarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdProducto", p.IdProducto);
                cmd.Parameters.AddWithValue("@Nombre", p.NombreProducto);
                cmd.Parameters.AddWithValue("@Descripcion", (object)p.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", p.PrecioVenta);
                cmd.Parameters.AddWithValue("@Stock", p.StockActual);
                cmd.Parameters.AddWithValue("@FechaVencimiento", (object)p.FechaVencimiento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Laboratorio", p.Laboratorio);
                cmd.Parameters.AddWithValue("@IdCategoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@IdMarca", p.IdMarca);
                cmd.Parameters.AddWithValue("@IdUnidad", p.IdUnidadMedida);

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Error al actualizar";
            }
        }

        // 5. Eliminar Producto (Cambio de estado o eliminación física)
        public string EliminarProducto(int id)
        {
            using (SqlConnection con = cn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("farm.sp_EliminarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", id);

                con.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Proceso completado";
            }
        }
    }
}
