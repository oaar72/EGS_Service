using ServicioEGS.Models;
using System;
using System.Data.SqlClient;
using System.Web.Http;

namespace ServicioEGS.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        // Realiza conexion de prueba al servidor de Base de datos
        public string Get()
        {
            string result = "Conexión a BD exitosa.";

            try
            {
                Conexion conn = new Conexion();
                string conexion = conn.getConnectionString();

                SqlConnection con = new SqlConnection(conexion);

                con.Open();
            }
            catch (Exception e)
            {
                result = e.StackTrace;
            }

            return result;
        }
    }
}
