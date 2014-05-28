using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Negocio.Models.Mapping
{
    public class VentaMap : EntityTypeConfiguration<Venta>
    {
        public VentaMap()
        {
            // Primary Key
            this.HasKey(t => t.VentaId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Venta");
            this.Property(t => t.VentaId).HasColumnName("VentaId");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.PedidoId).HasColumnName("PedidoId");
            this.Property(t => t.EstadoId).HasColumnName("EstadoId");

            // Relationships
            this.HasRequired(t => t.Estado)
                .WithMany(t => t.Ventas)
                .HasForeignKey(d => d.EstadoId);
            this.HasRequired(t => t.Pedido)
                .WithMany(t => t.Ventas)
                .HasForeignKey(d => d.PedidoId);

        }
    }
}
