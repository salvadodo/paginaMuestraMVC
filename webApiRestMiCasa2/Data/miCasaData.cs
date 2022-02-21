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
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
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
                        if (dr["Dueño"] == DBNull.Value)
                        {
                            int? resDueño = null;
                            registrosCasas.Add(new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                //Dueño = Convert.ToInt32(dr["Dueño"])
                                Dueño = resDueño
                            });
                        }
                        else
                        {
                            int resDueño = Convert.ToInt32(dr["Dueño"]);
                            registrosCasas.Add(new Casas()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                //Dueño = Convert.ToInt32(dr["Dueño"])
                                Dueño = resDueño
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
            using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
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
                    Casas oneCasa = new Casas();
                    while (dr.Read())
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
    }
}