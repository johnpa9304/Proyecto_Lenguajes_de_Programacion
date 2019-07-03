using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lenguajes_De_Programacion_Proyecto
{
    public class User
    {
        string mail { get; set; }
        string pwd { get; set; }
        string salt { get; set; }
    }
}