using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Datos
{
    public class Conexion
    {
        //private string cadena = @"Server=(localdb)\MSSQLLocalDB;Database=FarmaciaDB;Trusted_Connection=True;";}
        private string cadena = @"Server=E74976425;Database=FarmaciaDB;Trusted_Connection=True;";

        public SqlConnection GetConexion()
        {
            return new SqlConnection(cadena);
        }
}
}
