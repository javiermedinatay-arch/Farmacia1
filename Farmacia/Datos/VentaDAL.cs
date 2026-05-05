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

        /// <summary>
        /// Obtiene las categorías para llenar ComboBoxes en el formulario.
        /// </summary>
        public DataTable ListarCategorias()
        {
            using (SqlConnection con = cn.GetConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT idcategoria, nombre_categoria FROM farm.categoria", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Lista todos los productos registrados.
        /// </summary>
        public DataTable ListarProductos()
        {
            using (SqlConnection con = cn.GetConexion())
            {
                // Usamos la vista creada anteriormente para simplificar el código C#
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM farm.vw_ListarProductos", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Busca productos por nombre o laboratorio mediante procedimiento almacenado.
        /// </summary>
        public DataTable BuscarProducto(string texto)
        {
            using (SqlConnection con = cn.GetConexion())
            {
                // Deberás crear un SP llamado sp_BuscarProducto similar al del profesor
                SqlCommand cmd = new SqlCommand("farm.sp_BuscarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TextoBusqueda", texto);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos.
        /// </summary>
        public string InsertarProducto(Producto p)
        {
            using (SqlConnection con = cn.GetConexion())
            {
                SqlCommand cmd = new SqlCommand("farm.sp_InsertarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

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
                return result != null ? result.ToString() : "Error al insertar producto";
            }
        }

        /// <summary>
        /// Actualiza los datos de un producto existente.
        /// </summary>
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
                return result != null ? result.ToString() : "Error al actualizar producto";
            }
        }

        /// <summary>
        /// Elimina un producto (o cambia su estado a inactivo).
        /// </summary>
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
