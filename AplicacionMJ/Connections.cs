using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Path = System.IO.Path;

namespace AplicacionMJ
{
    internal class Connections
    {
    }

    public class Login {

        public Login() { }

        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        [MaxLength(50)]


        public string UserName { get; set; }
        [MaxLength(20)]

        public string Password { get; set; }  

    }

    #region Uso de datos de un usuario
    public class Informacion
    {
        public Informacion() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Registro { set; get; }

        [MaxLength(50)]
        public string Nombres { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }

        [MaxLength(100)]
        public string Edad { get; set; }

        [MaxLength(100)]
        public string Sexo { get; set; }

        [MaxLength(100)]
        public string NDocumento { get; set; }
    }


    public class Auxiliar
    {
        static object locker = new object();
        SQLiteConnection conexion;
        public Auxiliar() //Esto es un constructor
        {
            conexion = ConectarBD();
            conexion.CreateTable<Login>();
        }

        public SQLite.SQLiteConnection ConectarBD()
        {
            SQLiteConnection conexionBaseDatos;
            string nombreArchivo = "tdea.db3";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completaRuta = Path.Combine(ruta, nombreArchivo);
            conexionBaseDatos = new SQLiteConnection(completaRuta);
            return conexionBaseDatos;
        }

        //Selecionar 1 registro
        public Login SelecionarUno(string NombreUsuario, string ClaveUsuario)
        {
            lock (locker)
            {
                return conexion.Table<Login>().FirstOrDefault(x => x.UserName == NombreUsuario && x.Password == ClaveUsuario);
            }
        }

        //Selecionar Muchos
        public IEnumerable<Login> SeleccionarTodo()
        {
            lock (locker)
            {
                return (from i in conexion.Table<Login>() select i).ToList();
            }
        }

        //Guardar
        //Actualizar o insertar
        public int Guardar(Login registro)
        {
            lock (locker)
            {
                if (registro.Id == 0)
                {
                    return conexion.Insert(registro);
                }
                else
                {
                    return conexion.Update(registro);
                }
            }
        }
        //Eliminar
        public int Eliminar(int ID)
        {
            lock (locker)
            {
                return conexion.Delete<Login>(ID);
            }
        }

    }
    #endregion
}