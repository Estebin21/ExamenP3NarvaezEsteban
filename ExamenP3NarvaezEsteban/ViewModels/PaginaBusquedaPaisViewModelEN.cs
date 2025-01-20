using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite;
using System.Collections.ObjectModel;
using ExamenP3NarvaezEsteban.Models;

namespace ExamenP3NarvaezEsteban.ViewModels
{
    public class PaginaBusquedaPaisViewModelEN : BaseViewModel
    {
        public event Action PaisGuardado;

        private string _nombrePais;
        public string NombrePais
        {
            get => _nombrePais;
            set => SetProperty(ref _nombrePais, value);
        }

        private string _mensajeResultado;
        public string MensajeResultado
        {
            get => _mensajeResultado;
            set => SetProperty(ref _mensajeResultado, value);
        }

        public Command BuscarPaisCommand { get; }
        public Command LimpiarCommand { get; }

        public PaginaBusquedaPaisViewModelEN()
        {
            BuscarPaisCommand = new Command(async () => await BuscarPais());
            LimpiarCommand = new Command(Limpiar);
        }

        private async Task BuscarPais()
        {
            if (string.IsNullOrWhiteSpace(NombrePais))
            {
                MensajeResultado = "Por favor ingrese un nombre de país.";
                return;
            }

            var url = $"https://restcountries.com/v3.1/name/{NombrePais}?fields=name,region,maps";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync(url);
                    var paises = JsonConvert.DeserializeObject<List<PaisEN>>(response);
                    if (paises != null && paises.Count > 0)
                    {
                        var primerPais = paises.First();
                        GuardarPaisEnBD(primerPais);
                        MensajeResultado = $"Nombre oficial del país: {primerPais.Name.Official}\n- Región: {primerPais.Region}\n- Link de Google Maps: {primerPais.Maps.GoogleMaps}\n- Nombre: ENarvaez";
                        PaisGuardado?.Invoke();  // Dispara el evento cuando se guarda un país
                    }
                    else
                    {
                        MensajeResultado = "No se encontró ningún país con ese nombre.";
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeResultado = $"Error al buscar el país: {ex.Message}";
            }
        }

        private void GuardarPaisEnBD(PaisEN pais)
        {
            using (var conexion = new SQLiteConnection(App.DatabasePath))
            {
                conexion.CreateTable<PaisApiEN>();
                var paisDB = new PaisApiEN
                {
                    Nombre = pais.Name.Official,
                    Region = pais.Region,
                    EnlaceGoogleMaps = pais.Maps.GoogleMaps,
                    NombreUsuario = "ENarvaez" 
                };
                conexion.Insert(paisDB);
            }
        }

        private void Limpiar()
        {
            NombrePais = string.Empty;
            MensajeResultado = string.Empty;
        }
    }
}
