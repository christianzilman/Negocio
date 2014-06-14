using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Negocio.Models.Mapping;

namespace Negocio.Models
{
    public partial class NegocioContext : DbContext
    {
        static NegocioContext()
        {
            Database.SetInitializer<NegocioContext>(null);
        }

        public NegocioContext()
            : base("Name=NegocioContext")
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Comprador> Compradors { get; set; }
        public DbSet<DetalleOferta> DetalleOfertas { get; set; }
        public DbSet<DetallePedido> DetallePedidoes { get; set; }
        public DbSet<Estado> Estadoes { get; set; }
        public DbSet<FormaEntrega> FormaEntregas { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Pedido> Pedidoes { get; set; }
        public DbSet<Producto> Productoes { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TipoEntrega> TipoEntregas { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new CompradorMap());
            modelBuilder.Configurations.Add(new DetalleOfertaMap());
            modelBuilder.Configurations.Add(new DetallePedidoMap());
            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new FormaEntregaMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new NegocioMap());
            modelBuilder.Configurations.Add(new OfertaMap());
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new ProductoMap());
            modelBuilder.Configurations.Add(new SubCategoriaMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TipoEntregaMap());
            modelBuilder.Configurations.Add(new VentaMap());
        }
    }
}
