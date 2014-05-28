using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Negocio.Models.Mapping
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            // Primary Key
            this.HasKey(t => t.PedidoId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Pedido");
            this.Property(t => t.PedidoId).HasColumnName("PedidoId");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.CompradorId).HasColumnName("CompradorId");
            this.Property(t => t.EstadoId).HasColumnName("EstadoId");

            // Relationships
            this.HasRequired(t => t.Comprador)
                .WithMany(t => t.Pedidoes)
                .HasForeignKey(d => d.CompradorId);
            this.HasOptional(t => t.Estado)
                .WithMany(t => t.Pedidoes)
                .HasForeignKey(d => d.EstadoId);

        }
    }
}
