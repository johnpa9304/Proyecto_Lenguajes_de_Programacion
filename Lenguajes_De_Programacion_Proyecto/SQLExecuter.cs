using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lenguajes_De_Programacion_Proyecto
{
    public class SQLExecuter
    {
        private static string host = "127.0.0.1";
        private static string port = "5432";
        private static string user = "postgres";
        private static string pwd = "admin123456"; 
        private static string db = "Usuario";

        public static int ExecuteQuery(string q)
        {

            NpgsqlConnection db = new NpgsqlConnection(Conexion());
            NpgsqlCommand cmd = new NpgsqlCommand(q, db);
            db.Open();
            int r = cmd.ExecuteNonQuery(); 
            db.Close();
            return r;
        }
        private static string Conexion() => $"server = {host}; port = {port}; username = {user}; password ={pwd}; database = {db}";
    }  
} 