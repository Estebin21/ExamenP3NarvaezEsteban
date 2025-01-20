using System.Collections.ObjectModel;
using SQLite;
using ExamenP3NarvaezEsteban.Models;

namespace ExamenP3NarvaezEsteban.ViewModels
{
    public class PaginaListaPaisesViewModelEN : BaseViewModel
    {
        public ObservableCollection<string> Paises { get; set; }

        public PaginaListaPaisesViewModelEN()
        {
            Paises = new ObservableCollection<string>();
            CargarPaises();
        }

        public void CargarPaises()
        {
            Paises.Clear();
            using (var conexion = new SQLiteConnection(App.DatabasePath))
            {
                conexion.CreateTable<PaisApiEN>();
                var paisesBD = conexion.Table<PaisApiEN>().ToList();
                foreach (var pais in paisesBD)
                {
                    Paises.Add($"Nombre oficial del país: {pais.Nombre}\n- Región: {pais.Region}\n- Link de Google Maps: {pais.EnlaceGoogleMaps}\n- Nombre: {pais.NombreUsuario}");
                }
            }
        }
    }
}
