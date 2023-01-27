using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SQLite;
using System.Collections.ObjectModel;

namespace DnavarreteS7
{
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tEstudiante;


        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            Listar();
        }

        public async void Listar()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            tEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaEstudiantes.ItemsSource = tEstudiante;
        }

        //void OnSelection(System.Object sender, SelectedItemChangedEventArgs e)
        //{
         
        //}

        void btnRegresar_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        void ListaEstudiantes_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var obj = (Estudiante)e.Item;
            var item = obj.Id.ToString();
            var Id = Convert.ToInt32(item);
            var Nombre = obj.Nombre.ToString();
            var Usuario = obj.Usuario.ToString();
            var Contrasena = obj.Contrasenia.ToString();
            Navigation.PushAsync(new Elemento(Id, Nombre, Usuario, Contrasena));
        }
    }
}

