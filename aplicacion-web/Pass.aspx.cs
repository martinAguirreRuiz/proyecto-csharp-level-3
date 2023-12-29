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
    public partial class Pass : System.Web.UI.Page
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

        protected void btnActPass_Click(object sender, EventArgs e)
        {
            if (txtPassActual.Text.IsNullOrWhiteSpace())
            {
                Session["error"] = "Por favor complete los dos campos";
                Response.Redirect("Error.aspx", true);
            }
            if (txtPassNueva.Text.IsNullOrWhiteSpace())
            {
                Session["error"] = "Por favor complete los dos campos";
                Response.Redirect("Error.aspx", true);
            }
            if (txtPassActual.Text == Session["Pass"].ToString())
            {
                Session["Pass"] = txtPassNueva.Text;
                UserNegocio negocio = new UserNegocio();
                int id = (int)Session["Id"];
                try
                {
                    negocio.ActualizarPass(txtPassNueva.Text, id);
                    Response.Redirect("Ingreso.aspx", true);
                }
                catch (Exception ex )
                {
                    throw ex;
                }
            }
            else
            {
                Session["error"] = "La contraseña actual no es la correcta";
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx", true);
        }
    }
}