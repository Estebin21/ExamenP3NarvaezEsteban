namespace ExamenP3NarvaezEsteban.Models
{
    public class PaisEN
    {
        public Name Name { get; set; }
        public string Region { get; set; }
        public Maps Maps { get; set; }
    }

    public class Name
    {
        public string Official { get; set; }
    }

    public class Maps
    {
        public string GoogleMaps { get; set; }
    }
}
