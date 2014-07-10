using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Negocio.Models
{
    public partial class Item
    {
        public Item()
        {
            this.Productoes = new List<Producto>();
        }

        public int ItemId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar un Item")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar una Sub-Categoria")]
        public int SubCategoriaId { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
