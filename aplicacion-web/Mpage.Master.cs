using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aplicacion_web
{
    public partial class Mpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PrimeraCarga"] == null)
                {
                    Session.Add("error", "inicio del error");
                    Session.Add("dgvLista", new List<dominio.Articulo>());

                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.reiniciarCompra();

                    Session["PrimeraCarga"] = true;
                }
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            Session["señal"] = true;
            
            List<dominio.Articulo> lista = (List<dominio.Articulo>)Session["listaArticulos"];

            List<dominio.Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            Session["listaFiltrada"] = listaFiltrada;

            Response.Redirect("Default.aspx", false);
        }
    }
}