using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lenguajes_De_Programacion_Proyecto.Models
{
    public class Persona
    {
        //Representación de la tabla Persona (DB) como Clase (OO)

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public char genero { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime fechaNacimiento { get; set; }
        //public byte foto { get; set; }
    }
}