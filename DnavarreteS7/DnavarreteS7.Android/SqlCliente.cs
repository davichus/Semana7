using System;
using SQLite;
using System.IO;
using DnavarreteS7.Droid;

[assembly : Xamarin.Forms.Dependency(typeof(SqlCliente))]
namespace DnavarreteS7.Droid
{
    public class SqlCliente : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(ruta, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}

