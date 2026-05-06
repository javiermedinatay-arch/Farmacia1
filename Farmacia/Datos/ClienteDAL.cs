using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Datos
{
        public class ClienteDAL
        {
            Conexion cn = new Conexion();

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
        }
}
