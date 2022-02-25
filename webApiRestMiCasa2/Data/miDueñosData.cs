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
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                try
                {
                    while (dr.Read())
                    {
                        regDueños.Add(new Dueños()
                        {
                            idDueño=Convert.ToInt32(dr["idDueños"]),
                            Nombre=dr["Nombre"].ToString(),
                            Edad=Convert.ToInt32(dr["Edad"]),
                            Direccion=dr["Direccion"].ToString()
                        });
                    }
                    return regDueños;
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
    }
}