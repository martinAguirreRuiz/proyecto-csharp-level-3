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
    public partial class EdicionArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSeleccionado"] == null)
                {
                    Response.Redirect("Default.aspx", true);
                }
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                ddlMarca.DataSource = marcaNegocio.listarMarca();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                ddlCategoria.DataSource = categoriaNegocio.listarCategoria();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();
                if (Session["ArticuloSeleccionado"] == null)
                {
                    btnActDatos.Visible = false;
                    btnEliminar.Visible = false;
                }
                else
                {
                    btnAgregar.Visible = false;
                    dominio.Articulo articulo = (dominio.Articulo)Session["ArticuloSeleccionado"];
                    txtId.Text = articulo.Id.ToString();
                    txtCodigo.Text = articulo.Codigo.ToString();
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtCantidad.Text = articulo.Cantidad.ToString();

                    ListItem itemMarca = ddlMarca.Items.FindByText(articulo.Marca.Descripcion);
                    ddlMarca.ClearSelection();
                    itemMarca.Selected = true;

                    ListItem itemCategoria = ddlCategoria.Items.FindByText(articulo.Categoria.Descripcion);
                    ddlCategoria.ClearSelection();
                    itemCategoria.Selected = true;

                    if (!(articulo.UrlImagen.IsNullOrWhiteSpace()))
                    {
                        try
                        {
                            imgArticulo.ImageUrl = "~/Imagenes/" + articulo.UrlImagen;
                        }
                        catch (Exception)
                        {
                            imgArticulo.ImageUrl = "~/Imagenes/Placeholder.png";
                        }
                    }
                }


            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarArticulo.aspx", true);
        }

        protected void btnActDatos_Click(object sender, EventArgs e)
        {
            dominio.Articulo articulo = (dominio.Articulo)Session["ArticuloSeleccionado"];
            articulo.Id = int.Parse(txtId.Text);
            articulo.Codigo = txtCodigo.Text;
            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDescripcion.Text;
            articulo.Precio = int.Parse(txtPrecio.Text);
            articulo.Cantidad = int.Parse(txtCantidad.Text);
            articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
            articulo.Marca.Descripcion = ddlMarca.SelectedItem.Text;
            articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
            articulo.Categoria.Descripcion = ddlCategoria.SelectedItem.Text;
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                negocio.actualizarArticulo(articulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            txtId.Text = articulo.Id.ToString();
            txtCodigo.Text = articulo.Codigo.ToString();
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtPrecio.Text = articulo.Precio.ToString();
            txtCantidad.Text = articulo.Cantidad.ToString();

            ListItem itemMarca = ddlMarca.Items.FindByText(articulo.Marca.Descripcion);
            ddlMarca.ClearSelection();
            itemMarca.Selected = true;

            ListItem itemCategoria = ddlCategoria.Items.FindByText(articulo.Categoria.Descripcion);
            ddlCategoria.ClearSelection();
            itemCategoria.Selected = true;
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileImagen.HasFile)
                {
                    //User usuario = (User)Session["UserSeleccionado"];
                    //UserNegocio negocio = new UserNegocio();

                    dominio.Articulo articulo = (dominio.Articulo)Session["ArticuloSeleccionado"];
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    string ruta = Server.MapPath("./Imagenes/");
                    //int id = (int)Session["Id"];

                    string fileName = Path.GetFileName(fileImagen.FileName);

                    if (fileName.ToUpper().Contains(".JPG"))
                    {
                        fileImagen.PostedFile.SaveAs(ruta + "articulo-" + articulo.Id + ".jpg");

                        articulo.UrlImagen = "articulo-" + articulo.Id + ".jpg";
                    }
                    else if (fileName.ToUpper().Contains(".JPEG"))
                    {
                        fileImagen.PostedFile.SaveAs(ruta + "articulo-" + articulo.Id + ".jpeg");

                        articulo.UrlImagen = "articulo-" + articulo.Id + ".jpeg";

                    }
                    else if (fileName.ToUpper().Contains(".PNG"))
                    {
                        fileImagen.PostedFile.SaveAs(ruta + "articulo-" + articulo.Id + ".png");

                        articulo.UrlImagen = "articulo-" + articulo.Id + ".png";
                    }
                    else
                    {
                        Session["error"] = "El formato seleccionado no puede elegirse. Probar con archivos de formato '.jpg', '.jpeg' o '.png'";
                        Response.Redirect("Error.aspx", true);
                    }

                    negocio.actualizarImagen(articulo.UrlImagen, articulo.Id);



                    //Esto es para cargar la url de la img en ámbito web
                    //Image img = (Image)Master.FindControl("imgAvatar");
                    //img.ImageUrl = "~/Images/" + usuario.ImgPerfil;

                    imgArticulo.ImageUrl = "~/Imagenes/" + articulo.UrlImagen;

                }
            }
            catch (Exception)
            {
                Session["error"] = "Hubo un problema al cargar la imagen";
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.IsNullOrWhiteSpace() || txtNombre.Text.IsNullOrWhiteSpace() || txtDescripcion.Text.IsNullOrWhiteSpace() || txtPrecio.Text.IsNullOrWhiteSpace() || txtCantidad.Text.IsNullOrWhiteSpace())
            {
                Session["error"] = "Por favor completa todos los campos";
                Response.Redirect("Error.aspx", true);
            }
            else
            {
                dominio.Articulo articulo = new dominio.Articulo();

                //articulo.Id = int.Parse(txtId.Text);
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = int.Parse(txtPrecio.Text);
                articulo.Cantidad = int.Parse(txtCantidad.Text);
                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.Marca.Descripcion = ddlMarca.SelectedItem.Text;
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.Categoria.Descripcion = ddlCategoria.SelectedItem.Text;


                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.insertarArticulo(articulo);

                Response.Redirect("Default.aspx", true);
            }
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            lblEliminar.Visible = true;
            btnConfirmar.Visible = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            ArticuloNegocio negocio = new ArticuloNegocio();

            negocio.eliminarArticulo(id);

            Response.Redirect("Default.aspx", true);
        }
    }
}