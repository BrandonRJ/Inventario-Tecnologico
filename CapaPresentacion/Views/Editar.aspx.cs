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
    public partial class Editar : System.Web.UI.Page
    {
        // Servicio con la lógica del CRUD
        DispositivoService servicio = new DispositivoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Cargar datos solo la primera vez que entra a la página
            if (!IsPostBack)
            {
                // 1. Llenamos el DropDownList con categorías
                ddlCategorias.DataSource = servicio.ListarCategorias();
                ddlCategorias.DataTextField = "NombreCategoria";
                ddlCategorias.DataValueField = "IdCategoria";
                ddlCategorias.DataBind();
                ddlCategorias.Items.Insert(0, new ListItem("-- Seleccione --", ""));

                // 2. Validamos que venga un ID por la URL
                if (Request.QueryString["id"] == null)
                {
                    // Si no viene ID, regresamos al listado
                    Response.Redirect("Listado.aspx");
                    return;
                }

                // 3. Convertimos el ID del QueryString
                int id = int.Parse(Request.QueryString["id"]);

                // 4. Cargamos los datos del dispositivo en el formulario
                CargarDatos(id);
            }
        }

        private void CargarDatos(int id)
        {
            // Buscamos el dispositivo en la BD
            Dispositivo d = servicio.BuscarPorId(id);

            // Si no existe, regresamos al listado
            if (d == null)
            {
                Response.Redirect("Listado.aspx");
                return;
            }

            // Guardamos el ID en un HiddenField para usarlo al guardar
            hfIdDispositivo.Value = d.IdDispositivo.ToString();

            // Llenamos los controles del formulario
            txtNombre.Text = d.Nombre;
            txtMarca.Text = d.Marca;
            txtDescripcion.Text = d.Descripcion;
            txtCantidad.Text = d.Cantidad.ToString();
            txtPrecio.Text = d.Precio.ToString("0");

            // Seleccionamos la categoría actual
            ddlCategorias.SelectedValue = d.IdCategoria.ToString();

            // Cargamos el estado
            chkActivo.Checked = d.Estado;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación: si no hay ID, no se puede guardar
            if (string.IsNullOrEmpty(hfIdDispositivo.Value))
            {
                Response.Redirect("Listado.aspx");
                return;
            }

            // Convertimos el ID del HiddenField
            int id = int.Parse(hfIdDispositivo.Value);

            // Creamos un objeto con los datos editados
            Dispositivo d = new Dispositivo()
            {
                IdDispositivo = id,
                Nombre = txtNombre.Text,
                Marca = txtMarca.Text,
                Descripcion = txtDescripcion.Text,
                Cantidad = int.Parse(txtCantidad.Text),
                Precio = decimal.Parse(txtPrecio.Text),
                IdCategoria = int.Parse(ddlCategorias.SelectedValue),
                FechaIngreso = DateTime.Now, // Puedes usar la original si quieres conservarla
                Estado = chkActivo.Checked
            };

            // Actualizamos mediante la capa de negocio
            servicio.Actualizar(d);

            // Redirigimos al listado
            Response.Redirect("Listado.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cancelar vuelve a la página principal
            Response.Redirect("Listado.aspx");
        }
    }
}