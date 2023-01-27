using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using System.IO;
using System.Linq;

namespace DnavarreteS7
{
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;

        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string contraseña)
        {
            return db.Query<Estudiante>("select *from Estudiante where Usuario = ? and Contrasenia = ?", usuario, contraseña);
        }

        void  btnIniciar_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContrasena.Text);

                if (resultado.Count() >0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario o contraseña incorrectos", "Cerrar");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        void  btnRegistrar_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}

