using System;
using System.Collections.Generic;

namespace Negocio.Models
{
    public partial class DetalleOferta
    {
        public int DetalleOfertaId { get; set; }
        public int OfertaId { get; set; }
        public int ProductoId { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public virtual Oferta Oferta { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
