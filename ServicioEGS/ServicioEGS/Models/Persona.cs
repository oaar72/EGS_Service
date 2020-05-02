using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioEGS.Models
{
    [DataContract]
    public class Persona
    {
        [DataMember]
        private string nombre;
        [DataMember]
        private string aMaterno;
        [DataMember]
        private string aPaterno;
        [DataMember]
        private string telefono;
        [DataMember]
        private DateTime fecha;
        [DataMember]
        private string correo;
        [DataMember]
        private string password;
        
        public string getNombre()
        {
            return this.nombre;
        }

        public string getMaterno()
        {
            return this.aMaterno;
        }

        public string getPaterno()
        {
            return this.aPaterno;
        }

        public string getTelefono()
        {
            return this.telefono;
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }

        public string getCorreo()
        {
            return this.correo;
        }
    }
}