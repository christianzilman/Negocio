using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Negocio.Models
{
    public partial class Comprador
    {
        public Comprador()
        {
            this.Pedidoes = new List<Pedido>();
        }

        public int CompradorId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Apellido")]
        public string Apellido { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "El e-mail ingresado es inv�lido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el tel�fono")]
        public string Telefono { get; set; }
        public Nullable<int> UserId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la direcci�n")]
        public string Direccion { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}
