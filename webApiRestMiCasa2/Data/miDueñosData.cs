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
    public class miDueñosData
    {
        public static List<Dueños> registrosDueños()
        {
            List<Dueños> regDueños = new List<Dueños>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_selectAllDueños";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl=new DataTable();
                da.Fill(tbl);
                //SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                try
                {
                    //while (dr.Read())
                    //{
                    //    if (dr["Nombre"]==DBNull.Value)
                    //    {
                    //        string nullNombre = null;
                    //        regDueños.Add(new Dueños()
                    //        {
                    //            idDueño = Convert.ToInt32(dr["idDueño"]),
                    //            Nombre = nullNombre,
                    //            Edad = Convert.ToInt32(dr["Edad"]),
                    //            Direccion = dr["Direccion"].ToString()
                    //        });
                    //    }
                    //    else
                    //    {
                    //        regDueños.Add(new Dueños()
                    //        {
                    //            idDueño = Convert.ToInt32(dr["idDueño"]),
                    //            Nombre = dr["Nombre"].ToString(),
                    //            Edad = Convert.ToInt32(dr["Edad"]),
                    //            Direccion = dr["Direccion"].ToString()
                    //        });
                    //    }
                    //}
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        if (tbl.Rows[i]["Nombre"] == DBNull.Value)
                        {
                            string nullNombre = null;
                            regDueños.Add(new Dueños()
                            {
                                idDueño = Convert.ToInt32(tbl.Rows[i]["idDueño"]),
                                Nombre = nullNombre,
                                Edad = Convert.ToInt32(tbl.Rows[i]["Edad"]),
                                Direccion = tbl.Rows[i]["Direccion"].ToString()
                            });
                        }
                        else
                        {
                            regDueños.Add(new Dueños()
                            {
                                idDueño = Convert.ToInt32(tbl.Rows[i]["idDueño"]),
                                Nombre = tbl.Rows[i]["Nombre"].ToString(),
                                Edad = Convert.ToInt32(tbl.Rows[i]["Edad"]),
                                Direccion = tbl.Rows[i]["Direccion"].ToString()
                            });
                        }
                    }
                    //foreach(DataRow fila in tbl.Rows)
                    //{
                    //    if (fila["Nombre"] == DBNull.Value)
                    //    {
                    //        string nullDueño=null;
                    //        regDueños.Add(new Dueños()
                    //        {
                    //            idDueño = Convert.ToInt32(fila["idDueño"]),
                    //            Nombre =nullDueño,
                    //            Edad=Convert.ToInt32(fila["Edad"]),
                    //            Direccion=fila["Direccion"].ToString()
                    //        });
                    //    }
                    //    else
                    //    {
                    //        regDueños.Add(new Dueños()
                    //        {
                    //            idDueño = Convert.ToInt32(fila["idDueño"]),
                    //            Nombre = fila["Nombre"].ToString(),
                    //            Edad = Convert.ToInt32(fila["Edad"]),
                    //            Direccion = fila["Direccion"].ToString()
                    //        });

                    //    }
                    //}
                    return regDueños;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    //dr.Close();
                    if(con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
        public static Dueños selectDueño(int idDueño)
        {
            Dueños oneDueño=new Dueños();
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_selectOneDueños";
                cmd.Parameters.AddWithValue("@idDueño", idDueño);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                da.Fill(tbl);
                //SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                try
                {
                    //while (dr.Read())
                    //{
                    //    if (dr["Nombre"] == DBNull.Value)
                    //    {
                    //        string nullNombre = null;
                    //        oneDueño = new Dueños()
                    //        {
                    //            idDueño = Convert.ToInt32(dr["idDueño"]),
                    //            Nombre = nullNombre,
                    //            Edad = Convert.ToInt32(dr["Edad"]),
                    //            Direccion = dr["Direccion"].ToString()
                    //        };
                    //    }
                    //    else
                    //    {
                    //        oneDueño = new Dueños()
                    //        {
                    //            idDueño = Convert.ToInt32(dr["idDueño"]),
                    //            Nombre = dr["Nombre"].ToString(),
                    //            Edad = Convert.ToInt32(dr["Edad"]),
                    //            Direccion = dr["Direccion"].ToString()
                    //        };
                    //    }
                    //}
                    //for (int i = 0; i < tbl.Rows.Count; i++)
                    //{
                    //    if (tbl.Rows[i]["Nombre"] == DBNull.Value)
                    //    {
                    //        string nullNombre = null;
                    //        oneDueño = new Dueños()
                    //        {
                    //            idDueño = Convert.ToInt32(tbl.Rows[i]["idDueño"]),
                    //            Nombre = nullNombre,
                    //            Edad = Convert.ToInt32(tbl.Rows[i]["Edad"]),
                    //            Direccion = tbl.Rows[i]["Direccion"].ToString()
                    //        };
                    //    }
                    //    else
                    //    {
                    //        oneDueño = new Dueños()
                    //        {
                    //            idDueño = Convert.ToInt32(tbl.Rows[i]["idDueño"]),
                    //            Nombre = tbl.Rows[i]["Nombre"].ToString(),
                    //            Edad = Convert.ToInt32(tbl.Rows[i]["Edad"]),
                    //            Direccion = tbl.Rows[i]["Direccion"].ToString()
                    //        };
                    //    }
                    //}
                    foreach (DataRow fila in tbl.Rows)
                    {
                        if (fila["Nombre"] == DBNull.Value)
                        {
                            string nullDueño = null;
                            oneDueño = new Dueños()
                            {
                                idDueño = Convert.ToInt32(fila["idDueño"]),
                                Nombre = nullDueño,
                                Edad = Convert.ToInt32(fila["Edad"]),
                                Direccion = fila["Direccion"].ToString()
                            };
                        }
                        else
                        {
                            oneDueño = new Dueños()
                            {
                                idDueño = Convert.ToInt32(fila["idDueño"]),
                                Nombre = fila["Nombre"].ToString(),
                                Edad = Convert.ToInt32(fila["Edad"]),
                                Direccion = fila["Direccion"].ToString()

                            };
                        }
                    }
                    return oneDueño;
                }
                catch (Exception)
                {
                    throw;
                }
                finally 
                { 
                    //dr.Close();
                    if(con.State!= ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
        public static bool insertarDueño(Dueños newDueño)
        {
            using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_insertDueños";
                cmd.Parameters.AddWithValue("@Nombre", newDueño.Nombre);
                cmd.Parameters.AddWithValue("@Edad", newDueño.Edad);
                cmd.Parameters.AddWithValue("@Direccion", newDueño.Direccion);
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
        public static bool modificarDueño(Dueños modDueño)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection=con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_updateDueños";
                cmd.Parameters.AddWithValue("@idDueño", modDueño.idDueño);
                cmd.Parameters.AddWithValue("@Nombre", modDueño.Nombre);
                cmd.Parameters.AddWithValue("@Edad", modDueño.Edad);
                cmd.Parameters.AddWithValue("@Direccion", modDueño.Direccion);
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
        public static bool eliminarDueño(int eliDueño)
        {
            using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                SqlCommand cmd=new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandText = "sp_deleteDueños";
                cmd.Parameters.AddWithValue("@idDueño", eliDueño);
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