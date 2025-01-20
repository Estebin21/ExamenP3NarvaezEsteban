using SQLite;

namespace ExamenP3NarvaezEsteban.Models
{
    public class PaisApiEN
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Region { get; set; }
        public string EnlaceGoogleMaps { get; set; }
        public string NombreUsuario { get; set; } 
    }
}
