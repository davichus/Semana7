using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SQLite;
using System.IO;

namespace DnavarreteS7
{
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> rEliminar;
        IEnumerable<Estudiante> rActualizar;

        public Elemento(int id, string Nombre, string Usuario, string Contrasena)
        {
            InitializeComponent();
            txtNombre.Text = Nombre;
            txtUsuario.Text = Usuario;
            txtContrasena.Text = Contrasena;
            IdSeleccionado = id;

        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante WHERE Id =?", id);
        }


        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre = ?, Usuario = ?, Contrasenia = ? WHERE Id =?", nombre, usuario, contrasena, id);
        }

        void btnActualizar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Update(db, IdSeleccionado, txtNombre.Text, txtUsuario.Text, txtContrasena.Text);
                Navigation.PushAsync(new ConsultaRegistro());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        void btnEliminar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Delete(db, IdSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}

