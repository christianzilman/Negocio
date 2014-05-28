using System;
using System.Collections.Generic;

namespace Negocio.Models
{
    public partial class Estado
    {
        public Estado()
        {
            this.Pedidoes = new List<Pedido>();
            this.Ventas = new List<Venta>();
        }

        public int EstadoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
