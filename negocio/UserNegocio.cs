using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UserNegocio
    {
        public List<User> ListarUsers()
        {
            AccesoDatos datos = new AccesoDatos();
            List<User> lista = new List<User>();
            try
            {
                datos.setearProcedure("storedListarUsers");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    User aux = new User();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Email = (string)datos.Lector["email"];
                    aux.Pass = (string)datos.Lector["pass"];
                    aux.Nombre = datos.Lector["nombre"] != DBNull.Value ? (string)datos.Lector["nombre"] : "";
                    aux.Apellido = datos.Lector["apellido"] != DBNull.Value ? (string)datos.Lector["apellido"] : "";
                    aux.ImgPerfil = datos.Lector["urlImagenPerfil"] != DBNull.Value ? (string)datos.Lector["urlImagenPerfil"] : "";
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

        public void ActualizarNombre(string nombre, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("storedActNombre");
                datos.setearParametro("@nombre", nombre);
                datos.setearParametro("@id", id);
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

        public void ActualizarApellido(string apellido, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("storedActApellido");
                datos.setearParametro("@apellido", apellido);
                datos.setearParametro("@id", id);
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

        public void ActualizarPass(string pass, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("storedActPass");
                datos.setearParametro("@pass", pass);
                datos.setearParametro("@id", id);
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

        public void ActualizarImg(string img, int id)   
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("storedActualizarImg");
                datos.setearParametro("@img", img);
                datos.setearParametro("@id", id);
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

        public void InsertarUser(string email, string pass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("storedAgregarUser");
                datos.setearParametro("@email", email);
                datos.setearParametro("@pass", pass);
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
