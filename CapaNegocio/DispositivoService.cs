using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventarioTecnologia.CapaDatos;
using System.Data.Entity;
using System.Diagnostics;
using InventarioTecnologia.CapaDatos.Entidades;


namespace InventarioTecnologia.CapaNegocio
{
    public class DispositivoService
    {
        // 1. LISTAR TODOS LOS DISPOSITIVOS
        public List<Dispositivo> Listar()
        {
            try
            {
                using (var context = new InventarioContext())
                {
                    // Permite ver la consulta SQL en la ventana de Salida de Visual Studio
                    context.Database.Log = s => Debug.WriteLine(s);

                    return context.Dispositivos
                        .Include(d => d.Categoria) // Carga los datos de la tabla Categorias (Join)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                Debug.WriteLine("ERROR Listar: " + realMessage);
                throw new Exception("Error al listar: " + realMessage, ex);
            }
        }

        // 2. BUSCAR UN DISPOSITIVO POR SU ID
        public Dispositivo BuscarPorId(int id)
        {
            try
            {
                using (var context = new InventarioContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);

                    return context.Dispositivos
                        .Include(d => d.Categoria)
                        .FirstOrDefault(d => d.IdDispositivo == id);
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                Debug.WriteLine("ERROR BuscarPorId: " + realMessage);
                throw new Exception("Error al buscar: " + realMessage, ex);
            }
        }

        // 3. INSERTAR NUEVO DISPOSITIVO
        public void Insertar(Dispositivo dispositivo)
        {
            try
            {
                using (var context = new InventarioContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);

                    context.Dispositivos.Add(dispositivo);
                    context.SaveChanges(); // Guarda cambios en SQL Server
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                Debug.WriteLine("ERROR Insertar: " + realMessage);
                throw new Exception("Error al insertar: " + realMessage, ex);
            }
        }

        // 4. ACTUALIZAR DISPOSITIVO EXISTENTE
        public void Actualizar(Dispositivo dispositivo)
        {
            try
            {
                using (var context = new InventarioContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);

                    context.Entry(dispositivo).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                Debug.WriteLine("ERROR Actualizar: " + realMessage);
                throw new Exception("Error al actualizar: " + realMessage, ex);
            }
        }

        // 5. ELIMINAR DISPOSITIVO
        public void Eliminar(int id)
        {
            try
            {
                using (var context = new InventarioContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);

                    var dispositivo = context.Dispositivos.Find(id);
                    if (dispositivo != null)
                    {
                        context.Dispositivos.Remove(dispositivo);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                Debug.WriteLine("ERROR Eliminar: " + realMessage);
                throw new Exception("Error al eliminar: " + realMessage, ex);
            }
        }

        // 6. OBTENER CATEGORÍAS (Para llenar ComboBox/DropDownList)
        public List<Categoria> ListarCategorias()
        {
            try
            {
                using (var context = new InventarioContext())
                {
                    context.Database.Log = s => Debug.WriteLine(s);
                    return context.Categorias.ToList();
                }
            }
            catch (Exception ex)
            {
                string realMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                Debug.WriteLine("ERROR ListarCategorias: " + realMessage);
                throw new Exception("Error al listar categorías: " + realMessage, ex);
            }
        }
    }
}