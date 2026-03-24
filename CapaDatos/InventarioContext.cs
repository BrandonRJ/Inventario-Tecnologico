using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventarioTecnologia.CapaDatos.Entidades;
using System.Data.Entity;

namespace InventarioTecnologia.CapaDatos
{
    public class InventarioContext : DbContext
    {
        // El nombre "InventarioContext" debe coincidir con la cadena de conexión en Web.config
        public InventarioContext()
            : base("name=InventarioContext")
        {
        }

        // DbSet = representación de una tabla
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}