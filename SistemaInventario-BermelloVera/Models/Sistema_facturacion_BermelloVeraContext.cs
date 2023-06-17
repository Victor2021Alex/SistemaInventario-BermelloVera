using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaInventario_BermelloVera.Models
{
    public partial class Sistema_facturacion_BermelloVeraContext : DbContext
    {
        public Sistema_facturacion_BermelloVeraContext()
        {
        }

        public Sistema_facturacion_BermelloVeraContext(DbContextOptions<Sistema_facturacion_BermelloVeraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__FCE0399274B5A073");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_cliente");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .HasName("PK__DetalleF__4AE5C2FF8CDA3C60");

                entity.ToTable("DetalleFactura");

                entity.Property(e => e.IdDetalle)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_detalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.IdFactura).HasColumnName("Id_factura");

                entity.Property(e => e.IdProducto).HasColumnName("Id_producto");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK__DetalleFa__Id_fa__440B1D61");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__DetalleFa__Id_pr__44FF419A");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__01AC28291BEB932B");

                entity.ToTable("Empleado");

                entity.Property(e => e.IdEmpleado)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_empleado");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cargo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Numero).HasColumnName("numero");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Factura__A6DB93622B33C0EF");

                entity.ToTable("Factura");

                entity.Property(e => e.IdFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_factura");

                entity.Property(e => e.EstadoPago)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("estado_pago");

                entity.Property(e => e.FechaEmision)
                    .HasColumnType("date")
                    .HasColumnName("fechaEmision");

                entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");

                entity.Property(e => e.IdEmpleado).HasColumnName("Id_empleado");

                entity.Property(e => e.NumeroFactura).HasColumnName("numero_factura");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Factura__Id_clie__3D5E1FD2");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__Factura__Id_empl__3E52440B");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pago__405F9B773EB6A77E");

                entity.ToTable("Pago");

                entity.Property(e => e.IdPago)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_pago");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("date")
                    .HasColumnName("fecha_pago");

                entity.Property(e => e.IdFactura).HasColumnName("Id_factura");

                entity.Property(e => e.MetodoPago)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("metodo_pago");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK__Pago__Id_factura__412EB0B6");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__1D8EFF0156BA6D08");

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
