using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioEGS.Models
{
    public class Respuesta
    {
        private string error;
        private string mensaje;

        public string getError()
        {
            return error;
        }

        public string getMensaje()
        {
            return mensaje;
        }

        public void setError(string error)
        {
            this.error = error;
        }

        public void setMensaje(string mensaje)
        {
            this.mensaje = mensaje;
        }
    }
}