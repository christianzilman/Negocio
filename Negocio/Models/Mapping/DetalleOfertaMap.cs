using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Negocio.Models.Mapping
{
    public class DetalleOfertaMap : EntityTypeConfiguration<DetalleOferta>
    {
        public DetalleOfertaMap()
        {
            // Primary Key
            this.HasKey(t => t.DetalleOfertaId);

            // Properties
            // Table & Column Mappings
            this.ToTable("DetalleOferta");
            this.Property(t => t.DetalleOfertaId).HasColumnName("DetalleOfertaId");
            this.Property(t => t.OfertaId).HasColumnName("OfertaId");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");

            // Relationships
            this.HasRequired(t => t.Oferta)
                .WithMany(t => t.DetalleOfertas)
                .HasForeignKey(d => d.OfertaId);
            this.HasRequired(t => t.Producto)
                .WithMany(t => t.DetalleOfertas)
                .HasForeignKey(d => d.ProductoId);

        }
    }
}
