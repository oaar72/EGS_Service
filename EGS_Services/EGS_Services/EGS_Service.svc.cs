using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EGS_Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : EGS_Services
    {
        public string register(string name, string firstName, string lastName, DateTime date, string mail, string pass, string tel)
        {
            string token = "";

            Network.Connection conn = new Network.Connection();
            string conexion = conn.getConnectionString();

            SqlConnection con = new SqlConnection(conexion);

            con.Open();

            SqlCommand cmd = new SqlCommand("register", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@firstName", firstName));
            cmd.Parameters.Add(new SqlParameter("@lastName", lastName));
            cmd.Parameters.Add(new SqlParameter("@date", date));
            cmd.Parameters.Add(new SqlParameter("@mail", mail));
            cmd.Parameters.Add(new SqlParameter("@pass", pass));
            cmd.Parameters.Add(new SqlParameter("@tel", tel));
            cmd.Parameters.Add(new SqlParameter("@token", ""));

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                if (dr.Read())
                {
                    if (dr["ERROR"].ToString() == "")
                    {
                        token = dr["token"].ToString();
                    }
                    else
                    {
                        token = dr["ERROR"].ToString();
                    }

                }
            }
            catch (Exception e)
            {
                token += " Error al invocar SP (addUser). " + e.StackTrace;
            }

            return token;
        }
    }
}