using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace aplicacion_web
{
    public partial class AgregarAdmin : System.Web.UI.Page
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx", true);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            UserNegocio negocio = new UserNegocio();
            try
            {
                List<User> lista = negocio.ListarUsers();
                foreach (User user in lista) 
                {
                    if (user.Email == txtEmail.Text)
                    {
                        Session["error"] = "Ya existe un usuario registrado con este correo";
                        Response.Redirect("Error.aspx", true);
                    }
                }
                if (txtPass.Text != txtPass2.Text)
                {
                    Session["error"] = "Las contraseñas no coinciden";
                    Response.Redirect("Error.aspx", true);
                }
                negocio.InsertarUser(txtEmail.Text, txtPass.Text);
                Response.Redirect("Default.aspx", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}