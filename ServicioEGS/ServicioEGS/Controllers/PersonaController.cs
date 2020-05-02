using ServicioEGS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicioEGS.Controllers
{
    public class PersonaController : ApiController
    {
        // POST: api/Persona
        public string Post(string name, string firstName, string lastName, DateTime date, string mail, string pass, string tel)
        {
            string token = "";

            Conexion conn = new Conexion();
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
