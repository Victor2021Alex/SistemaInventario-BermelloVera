﻿using System;
using System.Collections.Generic;

namespace SistemaInventario_BermelloVera.Models
{
    public partial class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int? IdFactura { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public double? Descuento { get; set; }

        public virtual Factura? IdFacturaNavigation { get; set; }
        public virtual Producto? IdProductoNavigation { get; set; }
    }
}
