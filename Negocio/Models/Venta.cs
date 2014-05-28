using System;
using System.Collections.Generic;

namespace Negocio.Models
{
    public partial class Venta
    {
        public int VentaId { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public int PedidoId { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
