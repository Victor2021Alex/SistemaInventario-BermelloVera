﻿using System;
using System.Collections.Generic;

namespace SistemaInventario_BermelloVera.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
