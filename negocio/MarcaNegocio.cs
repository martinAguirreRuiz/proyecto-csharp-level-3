using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listarMarca()
        {
			AccesoDatos datos = new AccesoDatos();	
			List<Marca> lista = new List<Marca>();	
			try
			{
				datos.setearProcedure("storedListarMarcas");
				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					Marca aux = new Marca();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];
					lista.Add(aux);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
		public void insertarMarca(string marca) 
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearProcedure("storedInsertarMarca");
				datos.setearParametro("@marca", marca);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
    }
}
