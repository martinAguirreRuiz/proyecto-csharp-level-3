using Microsoft.Ajax.Utilities;
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
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserSeleccionado"] = null;
            }
        }

        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            //Primero tengo que validar que los dos campos estén llenos, si lo están entonces prosigo

            UserNegocio negocio = new UserNegocio();
            List<User> lista = new List<User>();
            bool flagE = false;
            bool flagP = false;
            try
            {
                lista = negocio.ListarUsers();
                if (lista.Count < 1)
                {
                    Session["error"] = "No hay usuarios registrados como administrador; consultar con el desarrollador del sitio";
                    Response.Redirect("Error.aspx", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (txtEmail.Text.IsNullOrWhiteSpace()) //Si devuelve true es porque no tiene que acceder
            {
                Session["error"] = "Por favor complete los dos campos";
                Response.Redirect("Error.aspx", true);

            }
            else
            {
                User aux = lista.Find(x => x.Email == txtEmail.Text);
                if (aux != null)
                {
                    flagE = true;
                    Session["UserSeleccionado"] = aux;
                }
                else
                {
                    flagE = false;
                }
            }

            if (txtPass.Text.IsNullOrWhiteSpace())
            {
                Session["error"] = "Por favor complete los dos campos";
                Response.Redirect("Error.aspx", true);
            }
            else
            {
                User aux = lista.Find(x => x.Pass == txtPass.Text);
                if (aux != null)
                {
                    flagP = true;
                    //Session["Id"] = aux.Id;
                    //Session["Nombre"] = aux.Nombre;
                    //Session["Apellido"] = aux.Apellido;
                    //Session["Img"] = aux.ImgPerfil;
                }
                else
                {
                    flagP = false;
                }
            }

            if (flagP && flagE)
            {
                //Session["Pass"] = txtPass.Text;
                //Session["Email"] = txtEmail.Text;
                Response.Redirect("Admin.aspx", false);
            }
            else
            {
                Session["error"] = "Email o contraseña incorrectos, por favor vuelve a intentar";
                Response.Redirect("Error.aspx", true);
            }
        }
    }
}