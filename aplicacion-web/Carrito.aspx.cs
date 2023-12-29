using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using dominio;
using negocio;

namespace aplicacion_web
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserSeleccionado"] = null;
                List<dominio.Articulo> listaCarr = (List<dominio.Articulo>)Session["dgvLista"];
                dgvCarrito.DataSource = listaCarr;
                dgvCarrito.DataBind();
                
                float total = 0;

                foreach (var item in listaCarr)
                {
                    float precio = item.CantidadAComprar * item.Precio;
                    total += precio;
                }

                string totalS = total.ToString();
                lblTotal.Text += totalS;
            }
        }

        protected void dgvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectRow")
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                string nombre = dgvCarrito.Rows[indice].Cells[0].Text;

                List<dominio.Articulo> listaCarr = (List<dominio.Articulo>)Session["dgvLista"];
                dominio.Articulo seleccionado = listaCarr.Find(x => x.Nombre == nombre);

                listaCarr.Remove(seleccionado);
                Session["dgvLista"] = listaCarr;

                dgvCarrito.DataSource = null;
                dgvCarrito.DataSource = listaCarr;
                dgvCarrito.DataBind();

                Response.Redirect("Default.aspx", true);
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            List<dominio.Articulo> listaCompra = (List<dominio.Articulo>)Session["dgvLista"];
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                negocio.realizarCompra(listaCompra);
                listaCompra.Clear();
                Session["dgvLista"] = listaCompra;
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}