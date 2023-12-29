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
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSeleccionado"] == null)
                {
                    Response.Redirect("Default.aspx", true);
                }
                ArticuloNegocio negocio = new ArticuloNegocio();
                List < dominio.Articulo > lista = negocio.listar();
                Session["listaEditable"] = lista;
                dgvArticulos.DataSource = lista;
                DataBind();
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvArticulos.SelectedDataKey.Value.ToString());

            List<dominio.Articulo> lista = (List<dominio.Articulo>)Session["listaEditable"];
            dominio.Articulo seleccionado = lista.Find(x => x.Id == id);
            Session["ArticuloSeleccionado"] = seleccionado;
            Response.Redirect("EdicionArticulo.aspx", true);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session["ArticuloSeleccionado"] = null;
            Response.Redirect("EdicionArticulo.aspx", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx", false);
        }
    }
}