using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lenguajes_De_Programacion_Proyecto
{
    /// <summary>
    /// Descripción breve de Servicio_Web
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    //[System.Web.Script.Services.ScriptService]
    public class Servicio_Web : System.Web.Services.WebService
    {
        [WebMethod]
        public int Registro(string nombres, string apellidos, char genero, string email, string password,
                                   DateTime fechaNacimiento)
        {
            string query = $"insert into public.\"persona\" (\"Nombre_usuario\", \"Apellido_usuario\", \"Genero_usuario\", " +
                $"\"Email_usuario\", \"Contraseña_usuario\", \"Fecha_Nacimiento_usuario\") values('{nombres}','{apellidos}','{genero}', '{email}', " +
                $"'{password}', '{fechaNacimiento}'); ";
            try
            {
                var r = SQLExecuter.ExecuteQuery(query);
                return r;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {e.Message}");
                return -1;
            }
        }

        /*[WebMethod]
        public int Insert(string Nombres, string Apellidos, char genero, string email, string password, 
                                   DateTime fechaNacimiento)
        {
            var query = $"insert into persona values('{Nombres}','{Apellidos}','{genero}', '{email}', " +
                $"'{password}', '{fechaNacimiento}'); ";
            try
            {
                //var r = SQLExecuter.ExecuteQuery("insert into aux values(6666)"); //inserta en una tabla auxiliar para 
                                                                                    //comprobar si el la clase que ejecuta está corriendo correctamente
                return SQLExecuter.ExecuteQuery(query);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {e.Message}");
                return -1;
            }
        }*/
    }
}
