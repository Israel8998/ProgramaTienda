using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramaTienda
{
    public class Producto
    {
        public String Nombre { get; set; }

        public int Cantidad { get; set; }

        public double Precio { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public long Codigo { get; set; }
    }
}