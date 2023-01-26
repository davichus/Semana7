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

        void btnRegresar_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

