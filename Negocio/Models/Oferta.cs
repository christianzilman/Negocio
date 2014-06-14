using System;
using System.Collections.Generic;

namespace Negocio.Models
{
    public partial class Oferta
    {
        public Oferta()
        {
            this.DetalleOfertas = new List<DetalleOferta>();
        }

        public int OfertaId { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaDesde { get; set; }
        public Nullable<System.DateTime> FechaHasta { get; set; }
        public Nullable<double> Total { get; set; }
        public virtual ICollection<DetalleOferta> DetalleOfertas { get; set; }
    }
}
