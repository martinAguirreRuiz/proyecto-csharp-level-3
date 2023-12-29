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
    public partial class Marcas : System.Web.UI.Page
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

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text.IsNullOrWhiteSpace())
            {
                Session["error"] = "Por favor completa el espacio con una marca";
                Response.Redirect("Error.aspx", true);
            }
            else
            {
                MarcaNegocio negocio = new MarcaNegocio();
                try
                {
                    negocio.insertarMarca(txtMarca.Text);
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