using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string Laboratorio { get; set; }
        public bool Estado { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }
        public int IdUnidadMedida { get; set; }
    }
}
