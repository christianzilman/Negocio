using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Negocio.Models.Mapping
{
    public class OfertaMap : EntityTypeConfiguration<Oferta>
    {
        public OfertaMap()
        {
            // Primary Key
            this.HasKey(t => t.OfertaId);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Oferta");
            this.Property(t => t.OfertaId).HasColumnName("OfertaId");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.FechaDesde).HasColumnName("FechaDesde");
            this.Property(t => t.FechaHasta).HasColumnName("FechaHasta");
            this.Property(t => t.Total).HasColumnName("Total");
        }
    }
}
