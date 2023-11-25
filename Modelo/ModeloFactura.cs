using Modelo.DBFR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloFactura
    {
        public class FacturaViewModel
        {         
            public int idFactura { get; set; }
            public int numero_factura { get; set; }
            public DateTime fecha_emision { get; set; }
            public float totalFactura { get; set; }            
            public int idReserva_id { get; set; }
        }
    }
}
