using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades { 
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public string TipoComprobante { get; set; }
        public decimal TotalVenta { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}