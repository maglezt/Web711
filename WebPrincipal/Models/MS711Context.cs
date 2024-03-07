using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebPrincipal.Models
{
    public partial class MS711Context : DbContext
    {
        public MS711Context()
        {
        }

        public MS711Context(DbContextOptions<MS711Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ComprasDetalle> ComprasDetalles { get; set; } = null!;
        public virtual DbSet<ComprasEncabezado> ComprasEncabezados { get; set; } = null!;
        public virtual DbSet<Etiqueta> Etiquetas { get; set; } = null!;
        public virtual DbSet<EtiquetasProducto> EtiquetasProductos { get; set; } = null!;
        public virtual DbSet<Impuesto> Impuestos { get; set; } = null!;
        public virtual DbSet<PersonasEmpresa> PersonasEmpresas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<VProducto> VProductos { get; set; } = null!;
        public virtual DbSet<VentasDetalle> VentasDetalles { get; set; } = null!;
        public virtual DbSet<VentasEncabezado> VentasEncabezados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComprasDetalle>(entity =>
            {
                entity.HasKey(e => e.IdCompraDetalle);

                entity.ToTable("ComprasDetalle");

                entity.Property(e => e.IdCompraDetalle).HasColumnName("idCompraDetalle");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CostoUnitario).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.IdCompraEncabezado).HasColumnName("idCompraEncabezado");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<ComprasEncabezado>(entity =>
            {
                entity.HasKey(e => e.IdCompraEncabezado);

                entity.ToTable("ComprasEncabezado");

                entity.Property(e => e.IdCompraEncabezado).HasColumnName("idCompraEncabezado");

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaHoraRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.ComprasEncabezados)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprasEncabezado_Proveedores");
            });

            modelBuilder.Entity<Etiqueta>(entity =>
            {
                entity.HasKey(e => e.IdEtiquetas);

                entity.HasIndex(e => e.Nombre, "UK_Etiquetas_Nombre")
                    .IsUnique();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EtiquetasProducto>(entity =>
            {
                entity.HasKey(e => e.IdEtiquetaProducto);

                entity.HasIndex(e => new { e.IdEtiqueta, e.IdProducto }, "UK_EtiquetasProductos")
                    .IsUnique();

                entity.HasOne(d => d.IdEtiquetaNavigation)
                    .WithMany(p => p.EtiquetasProductos)
                    .HasForeignKey(d => d.IdEtiqueta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EtiquetasProductos_Etiquetas");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.EtiquetasProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EtiquetasProductos_Productos");
            });

            modelBuilder.Entity<Impuesto>(entity =>
            {
                entity.HasKey(e => e.IdCatalogoImpuestos);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Tasa).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<PersonasEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdPersonaEmpresa);

                entity.Property(e => e.IdPersonaEmpresa).HasColumnName("idPersonaEmpresa");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHoraRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.HasIndex(e => e.Nombre, "UK_Productos_Nombre")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.HasIndex(e => e.IdPersonaEmpresa, "UK_Proveedores_IdPersonaEmpresa")
                    .IsUnique();

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.IdPersonaEmpresa).HasColumnName("idPersonaEmpresa");

                entity.HasOne(d => d.IdPersonaEmpresaNavigation)
                    .WithOne(p => p.Proveedore)
                    .HasForeignKey<Proveedore>(d => d.IdPersonaEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedores_PersonasEmpresas");
            });

            modelBuilder.Entity<VProducto>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vProductos");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Producto)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VentasDetalle>(entity =>
            {
                entity.HasKey(e => e.IdVentaDetalle);

                entity.ToTable("VentasDetalle");

                entity.Property(e => e.IdVentaDetalle).HasColumnName("idVentaDetalle");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdVentaEncabezado).HasColumnName("idVentaEncabezado");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.VentasDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentasDetalle_Productos");

                entity.HasOne(d => d.IdVentaEncabezadoNavigation)
                    .WithMany(p => p.VentasDetalles)
                    .HasForeignKey(d => d.IdVentaEncabezado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentasDetalle_VentasEncabezado");
            });

            modelBuilder.Entity<VentasEncabezado>(entity =>
            {
                entity.HasKey(e => e.IdVentaEncabezado);

                entity.ToTable("VentasEncabezado");

                entity.Property(e => e.IdVentaEncabezado).HasColumnName("idVentaEncabezado");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 6)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
