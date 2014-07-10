using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Negocio.Models
{
    public partial class SubCategoria
    {
        public SubCategoria()
        {
            this.Items = new List<Item>();
        }

        public int SubCategoriaId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la Sub-Categoría")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar una Categoría")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
