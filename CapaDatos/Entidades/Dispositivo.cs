using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioTecnologia.CapaDatos.Entidades
{
    [Table("Dispositivos")]
    public class Dispositivo
    {
        [Key]
        [Column("IdDispositivo")]
        public int IdDispositivo { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Marca")]
        public string Marca { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [Column("Precio")]
        public decimal Precio { get; set; }

        [Column("FechaIngreso")]
        public DateTime FechaIngreso { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

        // Llave foránea (El número)
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }

        // PROPIEDAD DE NAVEGACIÓN (Esto es lo que falta en tu imagen y causa el error)
        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }
    }
}