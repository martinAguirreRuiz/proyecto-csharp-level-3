using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aplicacion_web
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSeleccionado"] == null)
                {
                    Response.Redirect("Default.aspx", true);
                }
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text.IsNullOrWhiteSpace())
            {
                Session["error"] = "Por favor completa el espacio con una categoría";
                Response.Redirect("Error.aspx", true);
            }
            else
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                try
                {
                    negocio.insertarCategoria(txtCategoria.Text);
                    Response.Redirect("EdicionArticulo.aspx", false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EdicionArticulo.aspx", true);
        }
    }
}