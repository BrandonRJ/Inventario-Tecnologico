using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InventarioTecnologia.CapaNegocio;
namespace InventarioTecnologia.CapaPresentacion.Views
{
    public partial class Listado : System.Web.UI.Page
    {
        // Servicio que contiene la lógica del CRUD (CapaNegocio)
        DispositivoService servicio = new DispositivoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Page_Load se ejecuta cada vez que se carga la página.
            // !IsPostBack significa que solo cargamos datos la primera vez,
            // no cuando el usuario hace clic en un botón.
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            // Obtiene la lista de dispositivos desde la capa de negocio
            // y la asigna como fuente de datos del GridView.
            gvDispositivos.DataSource = servicio.Listar();

            // Refresca la tabla en pantalla
            gvDispositivos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            // Redirige a la página Crear.aspx para agregar un nuevo dispositivo
            Response.Redirect("Crear.aspx");
        }

        protected void gvDispositivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Obtiene el índice de la fila donde se dio clic
            int index = Convert.ToInt32(e.CommandArgument);

            // Obtiene el ID del dispositivo usando DataKeys del GridView
            int id = (int)gvDispositivos.DataKeys[index].Value;

            // Si el usuario presionó el botón "Editar"
            if (e.CommandName == "Editar")
            {
                // Enviamos al usuario a Editar.aspx con el ID por QueryString
                Response.Redirect("Editar.aspx?id=" + id);
            }

            // Si presionó "Eliminar"
            if (e.CommandName == "Eliminar")
            {
                // Se manda a capa de negocio a eliminar el registro
                servicio.Eliminar(id);

                // Recargamos la tabla para que se vea la actualización
                CargarGrid();
            }
        }
    }
}