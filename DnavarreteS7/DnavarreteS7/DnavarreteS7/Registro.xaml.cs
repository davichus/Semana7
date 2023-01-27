using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace DnavarreteS7
{
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();

        }

        void btn_agregar_Clicked(System.Object sender, System.EventArgs e)
        {
            var datos = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasenia = txtContrasenia.Text };
            con.InsertAsync(datos);
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
            Navigation.PushAsync(new Login());
        }
    }
}

