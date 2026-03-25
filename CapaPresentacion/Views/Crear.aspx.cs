using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioTecnologia.CapaDatos.Entidades;
using InventarioTecnologia.CapaNegocio;

namespace InventarioTecnologia.CapaPresentacion.Views
{
    public partial class Crear : System.Web.UI.Page
    {
        // Servicio que contiene la lógica del CRUD
        DispositivoService servicio = new DispositivoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo cargamos las categorías la PRIMERA vez que se entra a la página
            if (!IsPostBack)
            {
                // Llenamos el DropDownList con las categorías desde la capa de negocio
                ddlCategorias.DataSource = servicio.ListarCategorias();
                ddlCategorias.DataTextField = "NombreCategoria"; // Texto visible para el usuario
                ddlCategorias.DataValueField = "IdCategoria";     // Valor real del elemento (ID)
                ddlCategorias.DataBind();

                // Insertamos un valor inicial vacío para forzar la selección
                ddlCategorias.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Creamos una instancia del dispositivo con los valores del formulario
            Dispositivo d = new Dispositivo()
            {
                Nombre = txtNombre.Text,
                Marca = txtMarca.Text,
                Descripcion = txtDescripcion.Text,
                Cantidad = int.Parse(txtCantidad.Text),
                Precio = decimal.Parse(txtPrecio.Text),
                IdCategoria = int.Parse(ddlCategorias.SelectedValue),
                FechaIngreso = DateTime.Now, // Fecha del sistema
                Estado = true                // Siempre activo al crear
            };

            // Insertamos el nuevo dispositivo usando la capa de negocio
            servicio.Insertar(d);

            // Regresamos al listado una vez guardado con éxito
            Response.Redirect("Listado.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Si el usuario cancela, lo devolvemos al listado sin guardar nada
            Response.Redirect("Listado.aspx");
        }
    }
}