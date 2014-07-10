using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Negocio.Models
{
    public partial class Producto
    {
        public Producto()
        {
            this.DetalleOfertas = new List<DetalleOferta>();
            this.DetallePedidoes = new List<DetallePedido>();
        }

        public int ProductoId { get; set; }
        //[Required(ErrorMessage = "Debe Ingresar un Producto")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage = "Debe Ingresar un Precio")]
        public Nullable<double> PrecioCompra { get; set; }
        //[Required(ErrorMessage = "Debe Ingresar una Cantidad")]
        public Nullable<int> Cantidad { get; set; }
        //[Required(ErrorMessage = "Debe Ingresar una Fecha")]
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public byte[] Imagen { get; set; }
        //[Required(ErrorMessage = "Debe Seleccionar un Item")]
        public int ItemId { get; set; }
        //[Required(ErrorMessage = "Debe Seleccionar un Negocio")]
        public Nullable<int> NegocioId { get; set; }
        //[Required(ErrorMessage = "Debe Ingresar un Precio")]
        public Nullable<double> PrecioVenta { get; set; }
        public Nullable<int> Destacado { get; set; }
        public virtual ICollection<DetalleOferta> DetalleOfertas { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidoes { get; set; }
        public virtual Item Item { get; set; }
        public virtual Negocio Negocio { get; set; }
    }
}
