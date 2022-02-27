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
    public class miCasasDueñosData
    {
        public static List<CasasDueñosJoins> registrosInnerJoin()
        {
            List<CasasDueñosJoins> regCasasDueñosJoins = new List<CasasDueñosJoins>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["casasDueñosContext"].ConnectionString))
            {
                //string res = "";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_selectallDueñosInnerCasas";
                cmd.Connection = con;
                con.Open();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable tbl = new DataTable();
                //da.Fill(tbl);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                try
                {
                    while (dr.Read())
                    {
                        if (dr["Descripcion"] == DBNull.Value && dr["Nombre"] == DBNull.Value)
                        {
                            string nullNombre = null;
                            string nullDescripcion = null;
                            regCasasDueñosJoins.Add(new CasasDueñosJoins()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = nullDescripcion,
                                Nombre = nullNombre,
                                Edad=Convert.ToInt32(dr["Edad"]),
                                Direccion=dr["Direccion"].ToString()
                            });
                        }
                        else if (dr["Descripcion"] == DBNull.Value)
                        {
                            string nullDescripcion = null;
                            regCasasDueñosJoins.Add(new CasasDueñosJoins()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = nullDescripcion,
                                Nombre = dr["Nombre"].ToString(),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                Direccion = dr["Direccion"].ToString()
                            });
                        }
                        else if (dr["Nombre"] == DBNull.Value)
                        {
                            string nullNombre = null;
                            regCasasDueñosJoins.Add(new CasasDueñosJoins()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Nombre = nullNombre,
                                Edad = Convert.ToInt32(dr["Edad"]),
                                Direccion = dr["Direccion"].ToString()
                            });
                        }
                        else
                        {
                            regCasasDueñosJoins.Add(new CasasDueñosJoins()
                            {
                                idCasa = Convert.ToInt32(dr["idCasa"]),
                                tipodeCasa = dr["tipodeCasa"].ToString(),
                                Ubicacion = dr["Ubicacion"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                Direccion = dr["Direccion"].ToString()
                            });
                        }
                    }
                    return regCasasDueñosJoins;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    dr.Close();
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }

            }
        }
    }
}