using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Web.UI.HtmlControls;
using System.IO;

namespace aplicacion_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<dominio.Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["primerCarga"] == null)
                {
                    Session["señal"] = false;
                    Session["primerCarga"] = true;
                }
                bool señal = (bool)Session["señal"];

                if (señal)
                {
                    ListaArticulos = (List<dominio.Articulo>)Session["listaFiltrada"];
                }
                else
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    ListaArticulos = negocio.listar();
                    Session["listaArticulos"] = ListaArticulos;
                }
                repCards.DataSource = ListaArticulos;
                repCards.DataBind();

                Session["señal"] = false;
                Session["UserSeleccionado"] = null;
            }
        }



        protected void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            HtmlGenericControl miParrafo = (HtmlGenericControl)item.FindControl("miParrafo");

            dominio.Articulo articulo = ((List<dominio.Articulo>)Session["listaArticulos"]).Find(x => x.Nombre == miParrafo.InnerText);
            Session.Add("articulo", articulo);
            Response.Redirect("Articulo.aspx", false);
        }

        protected void imgArticulo_DataBinding(object sender, EventArgs e)
        {
            Image imgArticulo = (Image)sender;
            string urlImagen = imgArticulo.ImageUrl;

            if (string.IsNullOrEmpty(urlImagen) || !System.IO.File.Exists(Server.MapPath(urlImagen)))
            {
                imgArticulo.ImageUrl = "~/Imagenes/Placeholder.png";
            }
        }
    }
}