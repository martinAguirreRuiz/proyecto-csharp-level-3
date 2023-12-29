using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Microsoft.Ajax.Utilities;
using negocio;

namespace aplicacion_web
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSeleccionado"] == null)
                {
                    Response.Redirect("Default.aspx", true);
                }
                User usuario = (User)Session["UserSeleccionado"];
                txtEmail.Text = usuario.Email;
                txtPass.Text = usuario.Pass;
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;

                Session["NombreViejo"] = usuario.Email;
                Session["ApellidoViejo"] = usuario.Apellido;
                Session["Pass"] = usuario.Pass;
                Session["Id"] = usuario.Id;

                if (!(usuario.ImgPerfil.IsNullOrWhiteSpace()))
                {
                    try
                    {
                        imgPerfil.ImageUrl = "~/Imagenes/" + usuario.ImgPerfil;
                    }
                    catch (Exception)
                    {
                        imgPerfil.ImageUrl = "https://st3.depositphotos.com/6672868/13701/v/450/depositphotos_137014128-stock-illustration-user-profile-icon.jpg";
                    }
                }
            }
        }

        protected void btnActDatos_Click(object sender, EventArgs e)
        {
            string nombreViejo = Session["NombreViejo"].ToString();
            string apellidoViejo = Session["ApellidoViejo"].ToString();
            User usuario = (User)Session["UserSeleccionado"];
            //int id = (int)Session["Id"];

            if (nombreViejo != txtNombre.Text)
            {
                UserNegocio negocio = new UserNegocio();
                negocio.ActualizarNombre(txtNombre.Text, usuario.Id);
            }
            if (apellidoViejo != txtApellido.Text)
            {
                UserNegocio negocio = new UserNegocio();
                negocio.ActualizarApellido(txtApellido.Text, usuario.Id);
            }

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileImagen.HasFile)
                {
                    User usuario = (User)Session["UserSeleccionado"];
                    UserNegocio negocio = new UserNegocio();

                    string ruta = Server.MapPath("./Imagenes/");
                    //int id = (int)Session["Id"];

                    string fileName = Path.GetFileName(fileImagen.FileName);

                    if (fileName.ToUpper().Contains(".JPG"))
                    {
                        fileImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");

                        usuario.ImgPerfil = "perfil-" + usuario.Id + ".jpg";
                    }
                    else if (fileName.ToUpper().Contains(".JPEG"))
                    {
                        fileImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpeg");

                        usuario.ImgPerfil = "perfil-" + usuario.Id + ".jpeg";

                    }
                    else if (fileName.ToUpper().Contains(".PNG"))
                    {
                        fileImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".png");

                        usuario.ImgPerfil = "perfil-" + usuario.Id + ".png";
                    }
                    else
                    {
                        Session["error"] = "El formato seleccionado no puede elegirse. Probar con archivos de formato '.jpg', '.jpeg' o '.png'";
                        Response.Redirect("Error.aspx", true);
                    }

                    negocio.ActualizarImg(usuario.ImgPerfil, usuario.Id);



                    //Esto es para cargar la url de la img en ámbito web
                    //Image img = (Image)Master.FindControl("imgAvatar");
                    //img.ImageUrl = "~/Images/" + usuario.ImgPerfil;

                    imgPerfil.ImageUrl = "~/Imagenes/" + usuario.ImgPerfil;

                }
            }
            catch (Exception)
            {
                Session["error"] = "Hubo un problema al cargar la imagen";
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAdmin.aspx", false);
        }

        protected void btnArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarArticulo.aspx", false);
        }
    }
}