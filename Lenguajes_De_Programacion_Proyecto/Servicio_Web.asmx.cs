using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Security.Cryptography;

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
        private bool check(string salt_, string pwd, string hash_)
        {
            byte[] salt = Convert.FromBase64String(salt_);
            var pbkdf2 = new Rfc2898DeriveBytes(pwd, salt, 1000);
            var hashValue = pbkdf2.GetBytes(256);
            var stringHashedValue = Convert.ToBase64String(hashValue);
            return hash_.Equals(stringHashedValue);
        }

        [WebMethod]
        public int Registro(string nombres, string apellidos, char genero, string email, string password,
                                  DateTime fechaNacimiento)
        {
            List<string> ValoresCifrados = generaPwd(password);
            var salt = ValoresCifrados[0];
            var pwd = ValoresCifrados[1];

            check(salt, pwd, password);
            string query = $"insert into public.\"Aux_Persona\" (\"NOMBRES\", \"APELLIDOS\", \"GENERO\", " +
                $"\"EMAIL\", \"PASSWORDHASH\", \"PASSWORDSALT\", \"BIRTH\") values('{nombres}','{apellidos}','{genero}', '{email}', " +
                $"'{pwd}', '{salt}', '{fechaNacimiento}'); ";
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

        [WebMethod]
        public static List<string> generaPwd(string pwd)
        {
            List<string> valores = new List<string>();
            byte[] salt = new byte[8];

            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(salt);
            }

            // Se encripta los datos.
            var pbkdf2 = new Rfc2898DeriveBytes(pwd, salt, 1000);
            var hashValue = pbkdf2.GetBytes(128);
            var stringHashedValue = Convert.ToBase64String(hashValue);

            valores.Add(Convert.ToBase64String(salt));
            valores.Add(stringHashedValue);

            //valores almacena dos cosas
            //valores[0] => salt
            //valores[1] hash(pwd + salt)

            return valores;
        }

        //Métodos usados de pruebas 

        /*[WebMethod]
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
        }*/



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
