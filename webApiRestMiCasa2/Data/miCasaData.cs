using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webApiRestMiCasa2.Models;

namespace webApiRestMiCasa2.Data
{
    public class miCasaData
    {
        public static List<Casas> registrosCasas()
        {
            List<Casas> registrosCasas = new List<Casas>();  
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_selectAllCasas";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                try
                {
                    while (dr.Read())
                    {
                        if (dr["Dueño"]==DBNull.Value && dr["Descripcion"] == DBNull.Value)
                        {
                            int? nullDueño = null;
                            string nullDescripcion=null;
                            registrosCasas.Add(new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = nullDescripcion,
                                Dueño = nullDueño
                            });
                        }
                        else if (dr["Dueño"] == DBNull.Value)
                        {
                            int? nullDueño = null;
                            registrosCasas.Add(new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Dueño = nullDueño
                            });
                        }
                        else if (dr["Descripcion"]==DBNull.Value)
                        {
                            string nullDescripcion = null;
                            registrosCasas.Add(new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = nullDescripcion,
                                Dueño = Convert.ToInt32(dr["Dueño"])
                            });
                        }
                        else
                        {
                            registrosCasas.Add(new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Dueño = Convert.ToInt32(dr["Dueño"])
                            });
                        }
                    }
                    return registrosCasas;
                }
                catch (Exception)
                {
                    throw;
                }
                finally 
                { 
                    dr.Close();
                    if(con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }

            }
        }
        public static Casas selectCasa(int idCasa)
        {
            Casas oneCasa = new Casas();
            using (SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd=new SqlCommand();
                cmd.Connection=con;
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandText = "sp_selectOneCasas";
                cmd.Parameters.AddWithValue("@idCasa", idCasa);
                con.Open();
                SqlDataReader dr=cmd.ExecuteReader(CommandBehavior.Default);
                try
                {
                    while (dr.Read())
                    {
                        if (dr["Dueño"] == DBNull.Value && dr["Descripcion"] == DBNull.Value)
                        {
                            int? nullDueño = null;
                            string nullDescripcion = null;
                            oneCasa=new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = nullDescripcion,
                                Dueño = nullDueño
                            };
                        }
                        else if (dr["Dueño"] == DBNull.Value)
                        {
                            int? nullDueño = null;
                            oneCasa=new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Dueño = nullDueño
                            };
                        }
                        else if (dr["Descripcion"] == DBNull.Value)
                        {
                            string nullDescripcion = null;
                            oneCasa=new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = nullDescripcion,
                                Dueño = Convert.ToInt32(dr["Dueño"])
                            };
                        }
                        else
                        {
                            oneCasa=new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Dueño = Convert.ToInt32(dr["Dueño"])
                            };
                        }
                    }
                    return oneCasa;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    dr.Close();
                    if(con.State!= ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
        public static bool insertarCasa(Casas insCasa)
        {
            using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_insertCasas";
                cmd.Parameters.AddWithValue("@tipodecasa", insCasa.tipodeCasa);
                cmd.Parameters.AddWithValue("@Ubicacion", insCasa.Ubicacion);
                cmd.Parameters.AddWithValue("@Descripcion", insCasa.Descripcion);
                cmd.Parameters.AddWithValue("@Dueño", insCasa.Dueño);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    if(con.State!= ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
        public static bool modificarCasas(Casas modCasas)
        {
            using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd=new SqlCommand();
                cmd.Connection=con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_updateCasas";
                cmd.Parameters.AddWithValue("@idCasa", modCasas.idCasa);
                cmd.Parameters.AddWithValue("@tipodecasa", modCasas.tipodeCasa);
                cmd.Parameters.AddWithValue("@Ubicacion", modCasas.Ubicacion);
                cmd.Parameters.AddWithValue("@Descripcion", modCasas.Descripcion);
                cmd.Parameters.AddWithValue("@Dueño", modCasas.Dueño);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
        public static bool eliminarCasa(int eliCasa)
        {
            using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_deleteCasas";
                cmd.Parameters.AddWithValue("@idCasa", eliCasa);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    if(con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}