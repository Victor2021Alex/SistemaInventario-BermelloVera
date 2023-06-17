using System;
using System.Collections.Generic;

namespace SistemaInventario_BermelloVera.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int? IdFactura { get; set; }
        public DateTime? FechaPago { get; set; }
        public double? Monto { get; set; }
        public string? MetodoPago { get; set; }

        public virtual Factura? IdFacturaNavigation { get; set; }
    }
}
