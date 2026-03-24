using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioTecnologia.CapaDatos.Entidades
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }

        [Column("NombreCategoria")]
        public string NombreCategoria { get; set; }

        // Navegación: una categoría puede tener muchos dispositivos
        public virtual ICollection<Dispositivo> Dispositivos { get; set; }
    }
}