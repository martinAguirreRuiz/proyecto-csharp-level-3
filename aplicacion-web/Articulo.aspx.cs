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
    public partial class Articulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserSeleccionado"] = null;
                dominio.Articulo articulo = (dominio.Articulo)Session["articulo"];
                if (string.IsNullOrEmpty(articulo.UrlImagen))
                {
                    imgArticulo.ImageUrl = "~/Imagenes/Placeholder.png";
                }
                else
                {
                    imgArticulo.ImageUrl = "~/Imagenes/" + articulo.UrlImagen;
                }
                nombreArticulo.InnerText = articulo.Nombre;
                descArticulo.InnerText = articulo.Descripcion;
                double cuotas = (articulo.Precio * 2.5) / 24;
                precioArticulo.InnerText = "$" + articulo.Precio.ToString();
                cuotasArticulo.InnerText = "24 cuotas de $" + cuotas.ToString("0.00");
                stockArticulo.InnerText = "Stock: " + articulo.Cantidad.ToString();
                List<dominio.Articulo> listaFav = (List<dominio.Articulo>)Session["listaFav"];
                if (listaFav == null || listaFav.Count == 0)
                {

                }
                else
                {
                    dominio.Articulo articuloAux = listaFav.Find(x => x.Id == articulo.Id);
                    if (articuloAux != null)
                    {
                        btnFav.Enabled = false;
                        btnNoFav.Enabled = true;
                    }
                }
            }

        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                dominio.Articulo articulo = (dominio.Articulo)Session["articulo"];

                List<dominio.Articulo> ListaDgv = (List<dominio.Articulo>)Session["dgvLista"];

                dominio.Articulo articuloAux = ListaDgv.Find(x => x.Nombre == articulo.Nombre);

                ArticuloNegocio negocio = new ArticuloNegocio();

                if (articuloAux != null)
                {
                    if (articuloAux.CantidadAComprar + int.Parse(txtCantidad.Text) > articuloAux.Cantidad)
                    {
                        Session["error"] = "No se puede comprar más del stock disponible, ya tienes " + articuloAux.CantidadAComprar + " unidades de este producto en carrito";
                        Response.Redirect("Error.aspx", false);
                    }
                    else
                    {
                        articuloAux.CantidadAComprar += int.Parse(txtCantidad.Text);
                        negocio.actualizarCompra(articuloAux);
                        Session["dgvLista"] = ListaDgv;
                        Response.Redirect("Carrito.aspx", false);
                    }
                }
                else
                {
                    if (int.Parse(txtCantidad.Text) > articulo.Cantidad)
                    {
                        Session["error"] = "No se puede comprar más del stock disponible";
                        Response.Redirect("Error.aspx", false);
                    }
                    else
                    {
                        articulo.CantidadAComprar = int.Parse(txtCantidad.Text);
                        negocio.actualizarCompra(articulo);
                        ListaDgv.Add(articulo);
                        Session["dgvLista"] = ListaDgv;
                        Response.Redirect("Carrito.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnFav_Click(object sender, EventArgs e)
        {
            dominio.Articulo articulo = (dominio.Articulo)Session["articulo"];
            List<dominio.Articulo> listaFav = (List<dominio.Articulo>)Session["listaFav"];
            if (listaFav == null)
            {
                listaFav = new List<dominio.Articulo>();
            }
            dominio.Articulo articuloAux = listaFav.Find(x => x.Id == articulo.Id);
            if (articuloAux == null) //No lo encontró en la lista, lo tengo que agregar
            {
                listaFav.Add(articulo);
            }
            else //Ya se encuentra en la lista, no lo tengo que agregar
            {

            }
            Session["listaFav"] = listaFav;
            btnFav.Enabled = false;
            btnNoFav.Enabled = true;
            //Response.Redirect("Favoritos.aspx", false);
        }

        protected void btnNoFav_Click(object sender, EventArgs e)
        {
            dominio.Articulo articulo = (dominio.Articulo)Session["articulo"];
            List<dominio.Articulo> listaFav = (List<dominio.Articulo>)Session["listaFav"];
            dominio.Articulo articuloAux = listaFav.Find(x => x.Id == articulo.Id);
            listaFav.Remove(articuloAux);
            Session["listaFav"] = listaFav;
            btnNoFav.Enabled = false;
            btnFav.Enabled = true;
        }
    }
}