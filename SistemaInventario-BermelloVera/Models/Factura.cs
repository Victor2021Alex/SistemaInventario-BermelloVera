using System;
using System.Collections.Generic;

namespace SistemaInventario_BermelloVera.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
            Pagos = new HashSet<Pago>();
        }

        public int IdFactura { get; set; }
        public int? IdCliente { get; set; }
        public int? NumeroFactura { get; set; }
        public DateTime? FechaEmision { get; set; }
        public string? EstadoPago { get; set; }
        public double? Total { get; set; }
        public int? IdEmpleado { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Empleado? IdEmpleadoNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
