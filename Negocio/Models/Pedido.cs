using System;
using System.Collections.Generic;

namespace Negocio.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            this.DetallePedidoes = new List<DetallePedido>();
            this.FormaEntregas = new List<FormaEntrega>();
            this.Ventas = new List<Venta>();
        }

        public int PedidoId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<double> Total { get; set; }
        public int CompradorId { get; set; }
        public Nullable<int> EstadoId { get; set; }
        public virtual Comprador Comprador { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidoes { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<FormaEntrega> FormaEntregas { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
