using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI1.Models;

namespace WebAPI1.Data
{
    public class UsuarioData
    {
        public static bool Registrar(Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documentoidentidad", usuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@ciudad", usuario.Ciudad);
                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception es)
                {
                    return false;
                }
            }
        }
        public static bool Modificar (Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@documentoidentidad", usuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@ciudad", usuario.Ciudad);
                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception es)
                {
                    return false;
                }
            }
        }
         public static List<Usuario> Listar()
         {
             List<Usuario> listaUsuario = new  List<Usuario>();
             using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
             {
                 SqlCommand cmd = new SqlCommand("usp_listar", conexion);
                 cmd.CommandType = CommandType.StoredProcedure;

                 try
                 {
                     conexion.Open();
                     //cmd.ExecuteNonQuery();
                     using (SqlDataReader dr = cmd.ExecuteReader())
                     {
                         while (dr.Read())
                         {
                             listaUsuario.Add(new Usuario()
                             {
                                 IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                 DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                 Nombres = dr["Nombres"].ToString(),
                                 Telefono = dr["Telefono"].ToString(),
                                 Correo = dr["Correo"].ToString(),
                                 Ciudad = dr["Ciudad"].ToString(),
                                 FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
                             });
                         }
                     }

                     return listaUsuario;
                 }
                 catch (Exception es)
                 {
                     return listaUsuario;
                 }
             }
         }
        public static List<Usuario> Listar1()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
                            });
                        }

                    }



                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }
        }

        public static Usuario Obtener(int idusuario)
        {
            Usuario usuario = new Usuario(); 
            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", idusuario);
                try
                {
                    conexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        { 
                            usuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
                            };
                        }
                    }

                    return usuario;
                }
                catch (Exception es)
                {
                    return usuario;
                }
            }
        }
        public static bool Eliminar(int id )
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", id);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception es)
                {
                    return false;
                }
            }
        }
    }
}