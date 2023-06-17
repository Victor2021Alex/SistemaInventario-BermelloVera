using System;
using System.Collections.Generic;

namespace SistemaInventario_BermelloVera.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Facturas = new HashSet<Factura>();
        }

        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public int? Numero { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
