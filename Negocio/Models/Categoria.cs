using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Negocio.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            this.SubCategorias = new List<SubCategoria>();
        }

        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la Categoría")]
        public string Nombre { get; set; }
        public virtual ICollection<SubCategoria> SubCategorias { get; set; }
    }
}
