using System;
using System.Collections.Generic;

namespace Negocio.Models
{
    public partial class Producto
    {
        public Producto()
        {
            this.DetallePedidoes = new List<DetallePedido>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public Nullable<double> PrecioCompra { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public byte[] Imagen { get; set; }
        public int ItemId { get; set; }
        public Nullable<int> NegocioId { get; set; }
        public Nullable<double> PrecioVenta { get; set; }
        public Nullable<int> Destacado { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidoes { get; set; }
        public virtual Item Item { get; set; }
        public virtual Negocio Negocio { get; set; }
    }
}
