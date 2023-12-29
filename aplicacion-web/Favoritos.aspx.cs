using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace aplicacion_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserSeleccionado"] = null;
                List<dominio.Articulo> listaFav = (List<dominio.Articulo>)Session["listaFav"];

                if (listaFav == null || listaFav.Count == 0)
                {
                    lblFav.Visible = true;
                }
                else
                {
                    dgvFavoritos.DataSource = listaFav;
                    dgvFavoritos.DataBind();
                }
            }
        }

        protected void dgvFavoritos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectRow")
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                string nombre = dgvFavoritos.Rows[indice].Cells[0].Text;

                List<dominio.Articulo> listaFav = (List<dominio.Articulo>)Session["listaFav"];
                dominio.Articulo seleccionado = listaFav.Find(x => x.Nombre == nombre);

                listaFav.Remove(seleccionado);
                Session["listaFav"] = listaFav;

                dgvFavoritos.DataSource = null;
                dgvFavoritos.DataSource = listaFav;
                dgvFavoritos.DataBind();
            }
        }
    }
}